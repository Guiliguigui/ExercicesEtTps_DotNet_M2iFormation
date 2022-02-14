using ForumNouvelles.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumNouvelles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Forum forum = new Forum("SuperForumPointCom", "Défaut", "Moderateur", 22);
            ForumDAO forumDAO = new ();
            ModerateurDAO moderateurDAO = new ();
            AbonneDAO abonneDAO = new ();
            if (forumDAO.Save(forum))
                Console.WriteLine("Forum créé : \n" + forum);
            Moderateur defaultMod = (Moderateur)forum.Abonnes.First();
            if (moderateurDAO.Save(defaultMod))
                Console.WriteLine("Moderateur par défaut créé : \n" + forum);

            Abonne pierre = new Abonne("Pierre", "Dupont", 48, forum);
            Abonne pierre2 = new Abonne("Pierre2", "Dupont2", 480, forum);

            defaultMod.AjouterAbonne(pierre);
            defaultMod.AjouterAbonne(pierre2);
            Console.WriteLine("Ajout d'abonnés : " + string.Join("\n", defaultMod.ListerAbonnes()));
            
            defaultMod.BannirAbonne(pierre2);
            Console.WriteLine("Suppression d'un abonné : " + string.Join("\n", defaultMod.ListerAbonnes()));

            Nouvelle nouvelle1 = pierre.CreerNouvelle("sujet", "description");
            Nouvelle nouvelle2 = pierre.CreerNouvelle("sujet", "description");

            pierre.DeposerNouvelle(nouvelle1);
            pierre.DeposerNouvelle(nouvelle2);
            Console.WriteLine("Ajout de nouvelles : " + string.Join("\n", defaultMod.ListerNouvelles()));
            
            defaultMod.SupprimerNouvelle(nouvelle2);
            Console.WriteLine("Suppression d'une nouvelle : " + string.Join("\n", defaultMod.ListerNouvelles()));

            Console.WriteLine("Consultation d'une nouvelle : " + pierre.ConsulterNouvelleEtReponses("sujet"));
            defaultMod.RepondreNouvelle(nouvelle1, "réponse");
            Console.WriteLine("Consultation de la nouvelle avec un commentaire : " + pierre.ConsulterNouvelleEtReponses("sujet"));
            
        }
    }
}
