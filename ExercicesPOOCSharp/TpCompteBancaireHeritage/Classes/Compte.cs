using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompteBancaireHeritage.Classes
{
    internal class Compte
    {
        public double Solde { get; set; }
        public Client Client { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();

        private static int compteur = 0;
        public int Id { get; }

        public Compte(double depotInitial, Client client)
        {
            Solde = depotInitial;
            Client = client;
            compteur++;
            Id = compteur;
        }

        public virtual void EffectuerDepot(double depot)
        {
            Solde += depot;
            Operations.Add(new Operation(depot));
        }

        public virtual void EffectuerRetrait(double retrait)
        {
            Solde -= retrait;
            Operations.Add(new Operation(-retrait));
        }

        public override string ToString()
        {
            return $"{Client}\n" +
                $"\tSolde : {Solde}\n" +
                $"Liste Opérations :\n" +
                $"\t{string.Join("\n", Operations.Select(o => o.ToString()))}";

        }
    }
}
