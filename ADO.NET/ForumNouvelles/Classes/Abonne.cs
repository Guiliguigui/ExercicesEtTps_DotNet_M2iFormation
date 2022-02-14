using ForumNouvelles.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles
{
    internal class Abonne
    {
        private int id;
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
        public int Id { get => id; set => id = value; }

        public Nouvelle CreerNouvelle(string sujet, string texteDescriptif)
        {
            return new Nouvelle(sujet, texteDescriptif, Forum, this);
        }
        public bool DeposerNouvelle(Nouvelle nouvelle)
        {
            NouvelleDAO nouvelleDAO = new();
            Forum.Nouvelles.Add(nouvelle);
            return nouvelleDAO.Save(nouvelle);
        }
        public List<Nouvelle> ConsulterNouvelleEtReponses(string sujet)
        {
            NouvelleDAO nouvelleDAO = new();
            return nouvelleDAO.GetAll(sujet);
        }
        public bool RepondreNouvelle(Nouvelle nouvelle, string commentaire)
        {
            NouvelleDAO nouvelleDAO = new();
            Nouvelle reponse = new(nouvelle.Sujet, commentaire, Forum, this);
            nouvelle.Reponses.Add(reponse);
            return nouvelleDAO.Save(reponse);
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {this.GetType()} : {nameof(Prenom)}={Prenom}, {nameof(Nom)}={Nom}, {nameof(Age)}={Age.ToString()}}}";
        }
    }
}
