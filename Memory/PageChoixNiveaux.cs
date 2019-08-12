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
    public partial class PageChoixNiveaux : Form
    {
        private int idJoueur;

        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
        public int IdNiveaux { get => idNiveaux; set => idNiveaux = value; }

        private int idNiveaux;


        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";

        public PageChoixNiveaux(int idJoueur)
        {
            InitializeComponent();
            IdJoueur = idJoueur;
            IdNiveaux = idNiveaux;
        }

        private void ButtonDebutant_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(SqlConnectionString);

            Connection.Open();
            SqlCommand command = new SqlCommand("SELECT Id_D  FROM Niveaux WHERE Difficulte LIKE '%debutant%' ", Connection);
        
            IdNiveaux = (int)command.ExecuteScalar();

            JeuDebutant jeu = new JeuDebutant(IdJoueur,IdNiveaux);
            jeu.Show();
            Hide();
        }

        private void ButtonIntermediaire_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(SqlConnectionString);

            Connection.Open();
            SqlCommand command = new SqlCommand("SELECT Id_D  FROM Niveaux WHERE Difficulte LIKE '%intermediaire%' ", Connection);

            IdNiveaux = (int)command.ExecuteScalar();
            JeuIntermediaire jeu = new JeuIntermediaire(IdJoueur,IdNiveaux);
            jeu.Show();
            Hide();
        }

        private void ButtonExpert_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(SqlConnectionString);

            Connection.Open();
            SqlCommand command = new SqlCommand("SELECT Id_D  FROM Niveaux WHERE Difficulte LIKE '%expert%' ", Connection);

            IdNiveaux = (int)command.ExecuteScalar();
            JeuExpert jeu = new JeuExpert(IdJoueur,IdNiveaux);
            jeu.Show();
            Hide();
        }
    }
}
