using System;
using System.Collections.Generic;
using System.Text;



namespace MemoryLibrary
{
    public class Joueur
    {

        public static string AfficheMessageAuthentification()
        {
            return "Authentification ok, vous pouvez jouer";
        }

        public static string AfficheMessagePseudoMdP()
        {
            return "Veuillez entrer bon login et mot de passe";
        }

        public static string AfficheMessageConnexOK()
        {
            return "Connection ok vous pouvez jouer";
        }

        public static string AfficheMessageCréerPseudo()
        {
            return "Veuillez créer votre pseudo et mot de passe";
        }
    }
}
