using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompteBancaireHeritage.Classes
{
    internal class CompteEpargne : Compte
    {
        private decimal taux;

        public decimal Taux { get => taux; set => taux = value; }

        public CompteEpargne(decimal solde, Client client, decimal taux) : base(solde, client)
        {
            Taux = taux;
        }

        public bool CalculerInteret()
        {
            return Depot(new Operation(Solde * Taux / 100));
        }
    }
}
