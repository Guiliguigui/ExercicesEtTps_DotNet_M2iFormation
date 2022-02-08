using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles
{
    internal sealed class Moderateur : Abonne
    {
        public Moderateur(string prenom, string nom, int age, Forum forum) : base(prenom, nom, age, forum)
        {
        }

        public void SupprimerNouvelle(Nouvelle nouvelle)
        {
            Forum.Nouvelles.Remove(nouvelle);
        }
        public void BannirAbonne(Abonne abonne)
        {
            Forum.Abonnes.Remove(abonne);
        }
        public void AjouterAbonne(Abonne abonne)
        {
            Forum.Abonnes.Add(abonne);
        }
        public List<Abonne> ListerAbonnes()
        {
            return Forum.Abonnes;
        }
        public List<Nouvelle> ListerNouvelles()
        {
            return Forum.Nouvelles;
        }
    }
}
