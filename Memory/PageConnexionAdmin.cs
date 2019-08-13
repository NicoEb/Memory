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
    public partial class PageConnexionAdmin : Form
    {
        public PageConnexionAdmin()
        {
            InitializeComponent();
        }

        static string SqlConnectionString = @"Server=Admin-PC;Database=memoryBDD;Trusted_Connection=Yes";

        private void button3_Click(object sender, EventArgs e)
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
    }
}
