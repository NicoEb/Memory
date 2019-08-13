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
    public partial class PageConnexion : Form
    {
        private int idJoueur;

        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
        public PageConnexion()
        {
            InitializeComponent();
        }
        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";
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
                        PageChoixNiveaux jeu = new PageChoixNiveaux(IdJoueur);
                        jeu.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Veuillez crée votre compte");
                        textBoxPseudo.Text = "";
                        textBoxMdP.Text = "";
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
