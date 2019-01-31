using Memory;
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

namespace JeuxMemory
{
    public partial class Admin : Form
    {
        static string SqlConnectionString = @"Server=.\SQLExpress;Database=memoryBDD;Trusted_Connection=Yes";

        // rempli combobox avec liste des joueurs qui sont en BDD
        public Admin()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Joueurs ", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            comboBox2.Items.Clear();
            while (dr.Read())
            {

                comboBox2.Items.Add(dr[1].ToString() + " " + dr[2].ToString());
            }
            dr.Close();
            connection.Close();

        }

        

        

        private void BtRetour_Click(object sender, EventArgs e)
        {
            PageIdentification pageIdentification = new PageIdentification();
            pageIdentification.Show();
            Hide();
        }
        //suppression joueur en base de donnée
        private void button2_Click(object sender, EventArgs e)
        {
            
            string message = comboBox2.SelectedItem.ToString();
            string[] nomComplet = message.Split(' ');
            string Nom = nomComplet[0];
            string Prenom = nomComplet[1];
            

            SqlConnection connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            SqlCommand firstInsert =
                new SqlCommand("DELETE FROM Joueurs WHERE Nom_J = @Nom AND Prenom_J = @Prenom", connection);
            var nomParameter = new SqlParameter("@Nom", Nom);
            var prenomParameter = new SqlParameter("@Prenom", Prenom);
            firstInsert.Parameters.Add(nomParameter);
            firstInsert.Parameters.Add(prenomParameter);
            firstInsert.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show("Utilisateur supprimé");
            //comboBox2.Text ="";
        }
    }
}