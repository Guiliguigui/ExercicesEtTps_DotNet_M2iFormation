using System;
using System.Collections.Generic;

#nullable disable

namespace BanqueDbFirst.Models
{
    public partial class Compte
    {
        public int Id { get; set; }
        public decimal Solde { get; set; }
        public decimal Taux { get; set; }
        public decimal CoutOperation { get; set; }
        public int ClientId { get; set; }
    }
}
