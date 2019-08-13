using JeuxMemory;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Memory
{
    public partial class PageIdentification : Form
    {
        public PageIdentification()
        {
            InitializeComponent();
        }

        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";

         private void ButtonAuthentification(object sender, EventArgs e)
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
                MessageBox.Show("veuillez entrez votre Adresse email");
            }
            else
            if (Sexe.Text != "homme" && Sexe.Text != "femme")
            {
                MessageBox.Show("veuillez entrez homme ou femme");
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
                FirstInsert.Parameters.AddWithValue("@Nom", Nom.Text);
                FirstInsert.Parameters.AddWithValue("@Prenom", Prenom.Text);
                FirstInsert.Parameters.AddWithValue("@Adresse", Adresse.Text);
                FirstInsert.Parameters.AddWithValue("@Sexe", Sexe.Text);
                FirstInsert.Parameters.AddWithValue("@Pseudo", Pseudo.Text);
                FirstInsert.Parameters.AddWithValue("@MdP", MdP.Text);
                FirstInsert.ExecuteNonQuery();
                Connection.Close();


                MessageBox.Show("Autentification ok ,veuillez vous connecter avec votre pseudo et mot de passe ");
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
            PageConnexionAdmin jeu = new PageConnexionAdmin();
            jeu.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PageConnexion jeu = new PageConnexion();
            jeu.Show();
            Hide();
        }





    }

}
