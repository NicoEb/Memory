using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JeuxMemory;
namespace Memory
{
    class DataAcces
    {
        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get;  set; }

        public static InsererJoueur()
        {

            SqlConnection Connection = new SqlConnection(SqlConnectionString);
            Connection.Open();
            SqlCommand FirstInsert =
                 new SqlCommand("INSERT INTO Joueurs (Nom_J, Prenom_J, Adresse_J , Sexe_J , Pseudo_J , MdP_J) VALUES (@Nom,@Prenom,@Adresse,@Sexe,@Pseudo,@MdP)", Connection);
            FirstInsert.Parameters.AddWithValue("@Nom", Nom);
            FirstInsert.Parameters.AddWithValue("@Prenom", Prenom);
            FirstInsert.Parameters.AddWithValue("@Adresse", Adresse);
            FirstInsert.Parameters.AddWithValue("@Sexe", homme.Text);
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
    }
}
