using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5HeritageSalaire
{
    public class Salarie
    {
        private static int compteur = 0;
        private static int totalSalaires = 0;
        private int salaire;

        public string Matricule { get; set; }
        public string Categorie { get; set; }
        public string Service { get; set; }
        public string Nom { get; set; }
        public int Salaire { 
            get => salaire; 
            set {
                totalSalaires -= salaire; 
                salaire = value;
                totalSalaires += value; 
            } 
        }
        public static int Compteur { get => compteur; set => compteur = value; }
        public static int TotalSalaires { get => totalSalaires;}

        public virtual void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {Nom} est de {Salaire}");
        }
        public Salarie()
        {
            Compteur++;
        }
        public Salarie(string matricule, string categorie, string service, string nom, int salaire)
        {
            Matricule = matricule;
            Categorie = categorie;
            Service = service;
            Nom = nom;
            Salaire = salaire;
            Compteur++;
        }

        public virtual int CalculerSalaire()
        {
            return Salaire;
        }
    }
}
