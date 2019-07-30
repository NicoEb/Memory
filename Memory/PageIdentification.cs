﻿using JeuxMemory;
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
        private int idJoueur;

        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
        public PageIdentification()
        {
            InitializeComponent();
        }

        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";


       

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
               if (femme = false && homme = true)
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
                FirstInsert.Parameters.AddWithValue("@Sexe", );
                FirstInsert.Parameters.AddWithValue("@Pseudo", Pseudo.Text);
                FirstInsert.Parameters.AddWithValue("@MdP", MdP.Text);
                FirstInsert.ExecuteNonQuery();
                Connection.Close();


                MessageBox.Show("Autentification ok ,veuillez vous connecter avec votre pseudo et mot de passe ");
                Nom.Text = "";
                Prenom.Text = "";
                Adresse.Text = "";
                homme.Text = "";
                Pseudo.Text = "";
                MdP.Text = "";


            }
            DataAcces.InsererJoueur();
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


            JeuExpert jeu = new JeuExpert(IdJoueur);
            jeu.Show();
            Hide();

        }

        private void ButtonIntermediaire(object sender, EventArgs e) // lance le jeu en mode intermediaire
        {

            JeuIntermediaire jeu = new JeuIntermediaire(IdJoueur);
            jeu.Show();
            Hide();
        }

        private void ButtonDebutant(object sender, EventArgs e) //lance le jeu en mode débutant
        {

            
            JeuDebutant jeu = new JeuDebutant(IdJoueur);
            //ConnexionSelonNiveau();
            jeu.Show();
            Hide();
        }

        
        private void Connexion_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(SqlConnectionString);

            try
            {
                Connection.Open();

                SqlCommand command = Connection.CreateCommand();
                command.CommandText = "SELECT id_J FROM Joueurs WHERE Pseudo_J = @pseudo AND MdP_J = @password";

                command.Parameters.AddWithValue("@pseudo", textBoxPseudo.Text);
                command.Parameters.AddWithValue("@password", textBoxMdP.Text);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    if (reader.HasRows)
                    {
                        do
                        {
                            IdJoueur = Convert.ToInt32(reader[0]);
                        } while (reader.Read());

                        MessageBox.Show("Connexion ok");
                    }
                    else
                    {
                        MessageBox.Show("Veuillez crée votre compte");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

}
