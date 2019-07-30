using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class JeuDebutant : Form
    {

        private int idJoueur;

        public int IdJoueur { get => idJoueur; set => idJoueur = value; }

        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";

        bool AllowClick = false; // ce booléen autorise de cliquer
        PictureBox FirstGuess; // objet premiere selection
        Random Rnd = new Random(); // créer une instance générant un nombre aléatoire
        Timer ClickTimer = new Timer(); // crée un nouveau timer
        int Time = 30; // alloue la valeiur 30 au timer ci dessus
        
        Timer timer = new Timer { Interval = 1000 }; // intervalle de 1000 millisecondes ou 1 seconde pour le timer

        public JeuDebutant(int idJoueur) // création de la classe jeu débutant
        {
            InitializeComponent();
            IdJoueur = idJoueur;
        }
        private PictureBox[] PictureBoxes // on ajoute les pictures box a un tableau
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }
        
        private static IEnumerable<Image> Images // Stocke les images et les lie au jeu
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.img1,
                    Properties.Resources.img2,
                    Properties.Resources.img3,
                    Properties.Resources.img4,
                   
                };
            }
        }

        private void StartGameTimer() // démarre le timer du jeu et affiche le temps restant
        {
            timer.Start();
            timer.Tick += delegate
            {
                Time--;
                if (Time < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Temps écoulé");
                    ResetImages();
                }
                var SsTime = TimeSpan.FromSeconds(Time);

                Chrono.Text = "00: " + Time.ToString();
            };
        }
        private void ResetImages() // remet le jeu a 0 quand le temps est écoulé
        {
            foreach (var Pic in PictureBoxes)
            {
                Pic.Tag = null;
                Pic.Visible = true;
            }
            HideImages();
            SetRandomImages();
            Time = 30;
            timer.Start();
        }

        private void HideImages() // met les images face cachée
        {
            foreach (var Pic in PictureBoxes)
            {
                Pic.Image = Properties.Resources.question;
            }
        }

        private PictureBox GetFreeSlot() // place les images aléatoirement
        {
            int Num;

            do
            {
                Num = Rnd.Next(0, PictureBoxes.Count());
            }
            while (PictureBoxes[Num].Tag != null);
            return PictureBoxes[Num];
        }

        private void SetRandomImages() // permet de trouver deux images correspondantes ou non
        {
            foreach (var Image in Images)
            {
                GetFreeSlot().Tag = Image;
                GetFreeSlot().Tag = Image;
            }
        }

        private void ClickTimer_Tick(object sender, EventArgs e) // arrete le timer quand le jeu est fini
        {
            HideImages();

            AllowClick = true;
            ClickTimer.Stop();
        }
        

        public void ClickImage(object sender, EventArgs e) // définit le déroulement du jeu 
        {
            if (!AllowClick) return;

            var Pic = (PictureBox)sender;

            if (FirstGuess == null)
            {
                FirstGuess = Pic;
                Pic.Image = (Image)Pic.Tag;
                return;
            }
            Pic.Image = (Image)Pic.Tag;

            if (Pic.Image == FirstGuess.Image && Pic != FirstGuess)
            {
                Pic.Visible = FirstGuess.Visible = false;
                {
                    FirstGuess = Pic;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                HideImages();
            }
            else
            {
                AllowClick = false;
                ClickTimer.Start();
                ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
            }
            FirstGuess = null;
            if (PictureBoxes.Any(p => p.Visible)) return;
            timer.Stop();

            MessageBox.Show(" Bravo vous avez gagné en " + Time.ToString() + " secondes avec un score de " + Convert.ToString(ScoreCounter.Text) + " points ");

            // insère le temps et score de la partie en base de donnée
            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlCommand InsererTempsFin = new SqlCommand("INSERT INTO Partie(Temps_P,Score_P) VALUES (@temps,@score)", Connection);
            InsererTempsFin.Parameters.AddWithValue("@temps", (30 - Time));
            InsererTempsFin.Parameters.AddWithValue("@score", ScoreCounter.Text);
            InsererTempsFin.ExecuteNonQuery();
            Connection.Close();

        }

       

        private void StartGame(object sender, EventArgs e) // lancement du jeu
        {
            ScoreCounter.Text = "0";
            AllowClick = true;
            SetRandomImages();
            HideImages();
            StartGameTimer();
            ClickTimer.Interval = 1000;
            ClickTimer.Tick += ClickTimer_Tick;
            ButtonJouer.Enabled = false;
            
        }

        private void ButtonRetour(object sender, EventArgs e) // bouton retour a la page identification
        {
            PageIdentification pageIdentification = new PageIdentification();
            pageIdentification.Show();
            Hide();
            timer.Stop();
        }
    }
}
