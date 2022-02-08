using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompteBancaireHeritage.Classes
{
    internal class ComptePayant : Compte
    {
        public double CoutOperation { get; }
        public ComptePayant(double solde, Client client, double coutOperation) : base(solde, client)
        {
            CoutOperation = coutOperation;
        }

        public override void EffectuerDepot(double depot)
        {
            base.EffectuerDepot(depot);
            Solde -= CoutOperation;
            Operations.Add(new Operation(-CoutOperation));
        }

        public override void EffectuerRetrait(double retrait)
        {
            base.EffectuerRetrait(retrait);
            Solde -= CoutOperation;
            Operations.Add(new Operation(-CoutOperation));
        }
    }
}
