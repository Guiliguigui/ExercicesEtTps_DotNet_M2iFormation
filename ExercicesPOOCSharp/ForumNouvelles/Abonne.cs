using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles
{
    internal class Abonne
    {
        public Abonne(string prenom, string nom, int age, Forum forum)
        {
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Forum = forum;
        }

        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public Forum Forum { get; set; }

        public Nouvelle CreerNouvelle(string sujet, string texteDescriptif)
        {
            return new Nouvelle(sujet, texteDescriptif, Forum, this);
        }
        public void DeposerNouvelle(Nouvelle nouvelle)
        {
            Forum.Nouvelles.Add(nouvelle);
        }
        public Nouvelle ConsulterNouvelle(string sujet)
        {
            return Forum.Nouvelles.FirstOrDefault(n =>n.Sujet == sujet);
        }
        public void RepondreNouvelle(Nouvelle nouvelle, string commentaire)
        {
            nouvelle.Commentaires.Add(new KeyValuePair<Abonne, string>(this, commentaire));
        }

        public override string ToString()
        {
            return $"{{{this.GetType()} : {nameof(Prenom)}={Prenom}, {nameof(Nom)}={Nom}, {nameof(Age)}={Age.ToString()}}}";
        }
    }
}
