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
               
                FirstInsert.Parameters.AddWithValue("@Nom", Nom.Text);
                FirstInsert.Parameters.AddWithValue("@Prenom", Prenom.Text);
                FirstInsert.Parameters.AddWithValue("@Adresse", Adresse.Text);
                FirstInsert.Parameters.AddWithValue("@Sexe", Sexe.Text);
                FirstInsert.Parameters.AddWithValue("@Pseudo", Pseudo.Text);
                FirstInsert.Parameters.AddWithValue("@MdP", MdP.Text);
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
            ConnexionSelonNiveau();
            jeu.Show();
            Hide();
        }


        public void ConnexionSelonNiveau()
        {
            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlDataAdapter Select = new SqlDataAdapter("Select Pseudo_J, MdP_J From Joueurs where Pseudo_J ='" + textBoxPseudo.Text + "' and MdP_J ='" + textBoxMdP.Text + "'", Connection);


            int idGame = 0;
            SqlCommand InsererIDPartie = Connection.CreateCommand();
            InsererIDPartie.CommandText = "Select id_J From Joueurs where Pseudo_J ='" + textBoxPseudo.Text + "' and MdP_J ='" + textBoxMdP.Text + "'";
            idGame = (int)InsererIDPartie.ExecuteScalar();

            SqlCommand InsererIDenPartie = new SqlCommand("INSERT INTO Partie(FK_Id_J) VALUES (@idPlayer)", Connection);
             InsererIDenPartie.Parameters.AddWithValue("@idPlayer", idGame);
             InsererIDenPartie.ExecuteNonQuery();





            DataTable Dte = new DataTable();
            Select.Fill(Dte);
            if (Dte.Rows.Count == 1)
            {
                MessageBox.Show("connection ok vous pouvez jouer");

            }
            else
            {
                MessageBox.Show("Veuillez crée votre pseudo et mot de passe");
                textBox1.Text = "";
                textBox2.Text = "";
            }


            Connection.Close();
        }



        public void buttonAccès_Click(object sender, EventArgs e)
        {
            /*SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlDataAdapter Select = new SqlDataAdapter("Select Pseudo_J, MdP_J From Joueurs where Pseudo_J ='" + textBoxPseudo.Text + "' and MdP_J ='" + textBoxMdP.Text + "'", Connection);

            
            int idGame = 0;
            SqlCommand InsererIDPartie = Connection.CreateCommand();
            InsererIDPartie.CommandText="Select id_J From Joueurs where Pseudo_J ='" + textBoxPseudo.Text + "' and MdP_J ='" + textBoxMdP.Text + "'";
            idGame = (int)InsererIDPartie.ExecuteScalar();

            SqlCommand InsererIDenPartie = new SqlCommand("INSERT INTO Partie(FK_Id_J) VALUES (@idPlayer)", Connection);
            InsererIDenPartie.Parameters.AddWithValue("@idPlayer", idGame);
            InsererIDenPartie.ExecuteNonQuery();



            DataTable Dte = new DataTable();
            Select.Fill(Dte);
            if (Dte.Rows.Count == 1)
            {
                MessageBox.Show("connection ok vous pouvez jouer");
                
            }
            else
            {
                MessageBox.Show("Veuillez crée votre pseudo et mot de passe");
                textBox1.Text = "";
                textBox2.Text = "";
            }


            Connection.Close();*/

        }
    }

}
