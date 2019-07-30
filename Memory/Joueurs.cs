using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Joueurs
    {
        private string nom;
        private string prenom;
        private string adresse;
        private string pseudo;
        private string mdP;

        public string Nom { get ; set; }
        public string Prenom { get ; set; }

        public string Adresse { get => adresse; set => adresse = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string MdP { get => mdP; set => mdP = value; }

        public Joueurs(string nom, string prenom, string adresse, string pseudo, string mdP)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.pseudo = pseudo;
            this.mdP = mdP;
        }
    }
}
