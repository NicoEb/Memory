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
    public partial class JeuIntermediaire : Form
    {

        private int idJoueur;

        public int IdJoueur { get => idJoueur; set => idJoueur = value; }


        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";

            bool AllowClick = false;
            PictureBox FirstGuess;
            Random Rnd = new Random();
            Timer ClickTimer = new Timer();
            int Time = 45;
            Timer timer = new Timer { Interval = 1000 };

            public JeuIntermediaire(int idJoueur)
            {
                InitializeComponent();
                IdJoueur = idJoueur;

        }
            private PictureBox[] PictureBoxes
            {
                get { return Controls.OfType<PictureBox>().ToArray(); }
            }
            private static IEnumerable<Image> Images
            {
                get
                {
                    return new Image[]
                    {
                    Properties.Resources.img1,
                    Properties.Resources.img2,
                    Properties.Resources.img3,
                    Properties.Resources.img4,
                    Properties.Resources.img5,
                    Properties.Resources.img6,
                   
                    };
                }
            }

            private void StartGameTimer()
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

                    label1.Text = "00: " + Time.ToString();
                };
            }
            private void ResetImages()
            {
                foreach (var Pic in PictureBoxes)
                {
                    Pic.Tag = null;
                    Pic.Visible = true;
                }
                HideImages();
                SetRandomImages();
                Time = 45;
                timer.Start();
            }

            private void HideImages()
            {
                foreach (var Pic in PictureBoxes)
                {
                    Pic.Image = Properties.Resources.question;
                }
            }

            private PictureBox GetFreeSlot()
            {
                int Num;

                do
                {
                    Num = Rnd.Next(0, PictureBoxes.Count());
                }
                while (PictureBoxes[Num].Tag != null);
                return PictureBoxes[Num];
            }

            private void SetRandomImages()
            {
                foreach (var Image in Images)
                {
                    GetFreeSlot().Tag = Image;
                    GetFreeSlot().Tag = Image;
                }
            }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            HideImages();

            AllowClick = true;
            ClickTimer.Stop();
        }
        

        private void ClickImage(object sender, EventArgs e)
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

            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlCommand InsererTempsFin = new SqlCommand("INSERT INTO Partie(Temps_P,Score_P) VALUES (@temps,@score)", Connection);
            var temps = new SqlParameter("@temps", (45 - Time));
            var scores = new SqlParameter("@score", ScoreCounter.Text);
            InsererTempsFin.Parameters.Add(temps);
            InsererTempsFin.Parameters.Add(scores);
            InsererTempsFin.ExecuteNonQuery();
            Connection.Close();
        }

        private void StartGame(object sender, EventArgs e)
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

        private void ButtonRetour(object sender, EventArgs e)
        {
            PageIdentification pageIdentification = new PageIdentification();
            pageIdentification.Show();
            Hide();
            timer.Stop();
        }
    }
}
