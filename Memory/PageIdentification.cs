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


        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        private void button1_Click_1(object sender, EventArgs e)
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




                SqlConnection connection = new SqlConnection(SqlConnectionString);
                connection.Open();
                SqlCommand firstInsert =
                     new SqlCommand("INSERT INTO Joueurs (Nom_J, Prenom_J, Adresse_J , Sexe_J , Pseudo_J , MdP_J) VALUES (@Nom,@Prenom,@Adresse,@Sexe,@Pseudo,@MdP)", connection);
                var nomParameter = new SqlParameter("@Nom", Nom.Text);
                var prenomParameter = new SqlParameter("@Prenom", Prenom.Text);
                var adresseParameter = new SqlParameter("@Adresse", Adresse.Text);
                var sexeParameter = new SqlParameter("@Sexe", Sexe.Text);
                var pseudoParameter = new SqlParameter("@Pseudo", Pseudo.Text);
                var mdpParameter = new SqlParameter("@MdP", MdP.Text);
                firstInsert.Parameters.Add(nomParameter);
                firstInsert.Parameters.Add(prenomParameter);
                firstInsert.Parameters.Add(adresseParameter);
                firstInsert.Parameters.Add(sexeParameter);
                firstInsert.Parameters.Add(pseudoParameter);
                firstInsert.Parameters.Add(mdpParameter);
                firstInsert.ExecuteNonQuery();
                connection.Close();


                MessageBox.Show("Autentification ok ,choisir niveau de difficulté");
                Nom.Text = "";
                Prenom.Text = "";
                Adresse.Text = "";
                Sexe.Text = "";
                Pseudo.Text = "";
                MdP.Text = "";


            }            

        }

        private void Administrateur_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlDataAdapter select = new SqlDataAdapter("Select * From LoginAd where log ='" + textBox1.Text + "' and passowrd ='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            select.Fill(dt);
            if (dt.Rows.Count == 1)
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

        private void button2_Click(object sender, EventArgs e)
        {


            Jeux jeux = new Jeux();
            jeux.Show();
            Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Jeux1 jeux = new Jeux1();
            jeux.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Jeux2 jeux = new Jeux2();
            jeux.Show();
            Hide();
        }
    }

}
