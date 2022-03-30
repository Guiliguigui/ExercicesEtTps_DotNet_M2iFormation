using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banque.Models
{
    public class Compte
    {
        private int id;
        private decimal solde;
        private Client client;

        public int Id { get => id; set => id = value; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [DataType(DataType.Currency)]
        [Range(0.0, 1000000000.0)]
        public decimal Solde { get => solde; set => solde = value; }
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get => client; set => client = value; }
        public IEnumerable<Operation> Operations { get; set; }

        public Compte()
        {
            Operations = new List<Operation>();
        }
    }
}
