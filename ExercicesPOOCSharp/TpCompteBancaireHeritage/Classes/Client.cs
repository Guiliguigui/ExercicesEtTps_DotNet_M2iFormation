using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompteBancaireHeritage.Classes
{
    internal class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }

        public Client(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"{nameof(Nom)} : {Nom}, {nameof(Prenom)} : {Prenom}, {nameof(Telephone)} : {Telephone}";
        }
    }
}
