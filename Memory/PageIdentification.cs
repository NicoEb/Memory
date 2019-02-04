using JeuxMemory;
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
    public partial class PageIdentification : Form
    {
        public PageIdentification()
        {
            InitializeComponent();
        }

        static string SqlConnectionString = @"Server=.\SQLExpress;Database=memoryBDD;Trusted_Connection=Yes";


       

        private void ButtonAuthentification(object sender, EventArgs e) // permet de créer un joueur et de l'envoyer dans la base de données
        {
            if (Nom.Text == "")
            {
                MessageBox.Show("veuillez entrez votre nom");
            }
            else
               if (Prenom.Text == "")
            {
                MessageBox.Show("veuillez entrez votre prénom");
            }
            else
               if (Adresse.Text == "")
            {
                MessageBox.Show("veuillez entrez votre Adresse");
            }
            else
               if (Sexe.Text == "")
            {
                MessageBox.Show("veuillez entrez votre Sexe");
            }
            else
               if (Pseudo.Text == "")
            {
                MessageBox.Show("veuillez entrez un pseudo");
            }
            else
               if (MdP.Text == "")
            {
                MessageBox.Show("veuillez entrez un mot de passe");
            }
            else
            {




                SqlConnection Connection = new SqlConnection(SqlConnectionString);
                Connection.Open();
                SqlCommand FirstInsert =
                     new SqlCommand("INSERT INTO Joueurs (Nom_J, Prenom_J, Adresse_J , Sexe_J , Pseudo_J , MdP_J) VALUES (@Nom,@Prenom,@Adresse,@Sexe,@Pseudo,@MdP)", Connection);
                var NomParameter = new SqlParameter("@Nom", Nom.Text);
                var PrenomParameter = new SqlParameter("@Prenom", Prenom.Text);
                var AdresseParameter = new SqlParameter("@Adresse", Adresse.Text);
                var SexeParameter = new SqlParameter("@Sexe", Sexe.Text);
                var PseudoParameter = new SqlParameter("@Pseudo", Pseudo.Text);
                var MdpParameter = new SqlParameter("@MdP", MdP.Text);
                FirstInsert.Parameters.Add(NomParameter);
                FirstInsert.Parameters.Add(PrenomParameter);
                FirstInsert.Parameters.Add(AdresseParameter);
                FirstInsert.Parameters.Add(SexeParameter);
                FirstInsert.Parameters.Add(PseudoParameter);
                FirstInsert.Parameters.Add(MdpParameter);
                FirstInsert.ExecuteNonQuery();
                Connection.Close();


                MessageBox.Show("Autentification ok ,choisir niveau de difficulté");
                Nom.Text = "";
                Prenom.Text = "";
                Adresse.Text = "";
                Sexe.Text = "";
                Pseudo.Text = "";
                MdP.Text = "";


            }            

        }

        private void ButtonAdministrateur(object sender, EventArgs e) // permet de s'identifier en tant qu'admin
        {
            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            SqlDataAdapter Select = new SqlDataAdapter("Select * From LoginAd where log ='" + textBox1.Text + "' and passowrd ='" + textBox2.Text + "'", Connection);
            DataTable Dt = new DataTable();
            Select.Fill(Dt);
            if (Dt.Rows.Count == 1)
            {
                Hide();
                Admin admin = new Admin();
                admin.Show();

            }
            else
            {
                MessageBox.Show("Veuillez entre bon login et mot de passe");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void ButtonExpert(object sender, EventArgs e) // lance le jeu en mode expert
        {


            JeuExpert jeu = new JeuExpert();
            jeu.Show();
            Hide();

        }

        private void ButtonIntermediaire(object sender, EventArgs e) // lance le jeu en mode intermediaire
        {

            JeuIntermediaire jeu = new JeuIntermediaire();
            jeu.Show();
            Hide();
        }

        private void ButtonDebutant(object sender, EventArgs e) //lance le jeu en mode débutant
        {
            JeuDebutant jeu = new JeuDebutant();
            jeu.Show();
            Hide();
        }
    }

}
