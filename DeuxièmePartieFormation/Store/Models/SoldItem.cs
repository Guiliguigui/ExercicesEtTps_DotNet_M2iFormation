using System;
using System.Collections.Generic;

#nullable disable

namespace Store.Models
{
    public partial class SoldItem
    {
        public int SoldItemId { get; set; }
        public int StoreId { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Store Store { get; set; }
    }
}
