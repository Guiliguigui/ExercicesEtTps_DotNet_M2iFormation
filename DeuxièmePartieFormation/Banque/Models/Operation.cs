using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banque.Models
{
    public class Operation
    {
        private int id;
        private int compteId;
        private decimal montant;
        private DateTime dateOperation;
        private Compte compte;

        public int Id { get => id; set => id = value; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [DataType(DataType.Currency)]
        [Range(0.01, 10000.0)]
        public decimal Montant { get => montant; set => montant = value; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }
        [Required]
        public int CompteId { get => compteId; set => compteId = value; }
        [ForeignKey("CompteId")]
        public Compte Compte { get => compte; set => compte = value; }
    }
}
