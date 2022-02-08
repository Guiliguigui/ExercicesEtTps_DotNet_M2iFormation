using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompteBancaireHeritage.Classes
{
    internal class Operation
    {
        public DateTime DateOperation { get; set; } = DateTime.Now;
        public double Montant { get; set; }

        public Operation(double montant)
        {
            Montant = montant;
        }

        public override string ToString()
        {
            return $"Date Operation : {DateOperation}, {nameof(Montant)} : {Montant}";
        }
    }
}
