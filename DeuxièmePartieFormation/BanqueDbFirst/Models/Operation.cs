using System;
using System.Collections.Generic;

#nullable disable

namespace BanqueDbFirst.Models
{
    public partial class Operation
    {
        public int Id { get; set; }
        public DateTime DateOperation { get; set; }
        public decimal Montant { get; set; }
        public int CompteId { get; set; }
    }
}
