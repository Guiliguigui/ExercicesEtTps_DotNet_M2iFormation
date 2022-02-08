using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompteBancaireHeritage.Classes
{
    internal class CompteEpargne : Compte
    {
        public double TauxRemuneration { get; set; }
        public CompteEpargne(double solde, Client client, double tauxRemuneration) : base(solde, client)
        {
            TauxRemuneration = tauxRemuneration;
        }

        public double CalculerInterets()
        {
            double interets = TauxRemuneration * Solde / 100;
            Operations.Add(new Operation(interets));
            return interets;
        }

    }
}
