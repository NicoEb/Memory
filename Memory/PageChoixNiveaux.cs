using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public PageChoixNiveaux(int idJoueur)
        {
            InitializeComponent();
            IdJoueur = idJoueur;
        }

        private void ButtonDebutant_Click(object sender, EventArgs e)
        {
            JeuDebutant jeu = new JeuDebutant(IdJoueur);
            jeu.Show();
            Hide();
        }

        private void ButtonIntermediaire_Click(object sender, EventArgs e)
        {
            JeuIntermediaire jeu = new JeuIntermediaire(IdJoueur);
            jeu.Show();
            Hide();
        }

        private void ButtonExpert_Click(object sender, EventArgs e)
        {
            JeuExpert jeu = new JeuExpert(IdJoueur);
            jeu.Show();
            Hide();
        }
    }
}
