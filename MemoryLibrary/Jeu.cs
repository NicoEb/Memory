using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryLibrary
{
    public static class Jeu
    {
        public static string AfficheMessageVictoire(int temps, string score)
        {
            return "Bravo vous avez gagné en " + temps.ToString() + " secondes avec un score de " + score + " points ";
        }

        public static string AfficheMessageTempsEcoulé()
        {
            return "Temps écoulé";
        }
    }
}
