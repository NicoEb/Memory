﻿using Memory;
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
        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";

        public Admin() // Remplit combobox avec liste des joueurs qui sont en BDD
        {
            InitializeComponent();
            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlCommand Cmd = new SqlCommand("select * from Joueurs ", Connection);
            SqlDataReader Dr = Cmd.ExecuteReader();
            comboBox2.Items.Clear();
            while (Dr.Read())
            {

                comboBox2.Items.Add(Dr[1].ToString() + " " + Dr[2].ToString());
            }
            Dr.Close();
            Connection.Close();

        }

        

        

        private void ButtonRetour(object sender, EventArgs e)
        {
            PageIdentification pageIdentification = new PageIdentification();
            pageIdentification.Show();
            Hide();
        }
        private void ButtonSupprimer(object sender, EventArgs e) //Suppression joueur en base de donnée
        {
            
            string Message = comboBox2.SelectedItem.ToString();
            string[] NomComplet = Message.Split(' ');
            string Nom = NomComplet[0];
            string Prenom = NomComplet[1];
            

            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlCommand FirstInsert =
                new SqlCommand("DELETE FROM Joueurs WHERE Nom_J = @Nom AND Prenom_J = @Prenom", Connection);
            FirstInsert.Parameters.AddWithValue("@Nom", Nom);
            FirstInsert.Parameters.AddWithValue("@Prenom", Prenom);
            FirstInsert.ExecuteNonQuery();

            Connection.Close();

            MessageBox.Show("Utilisateur supprimé");
            comboBox2.Text ="";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlCommand Cmd = new SqlCommand("select * from Joueurs ", Connection);
            SqlDataReader Dr = Cmd.ExecuteReader();
            listView1.Items.Clear();
            while (Dr.Read())
            {

                listView1.Items.Add(Dr[1].ToString() + " " + Dr[2].ToString());
            }
            Dr.Close();
            Connection.Close();


        }
    }
}