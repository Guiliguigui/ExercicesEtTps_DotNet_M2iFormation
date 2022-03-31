using System;
using System.Collections.Generic;

#nullable disable

namespace BanqueDbFirst.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
    }
}
