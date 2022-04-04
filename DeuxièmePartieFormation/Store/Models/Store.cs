using System;
using System.Collections.Generic;

#nullable disable

namespace Store.Models
{
    public partial class Store
    {
        public Store()
        {
            SoldItems = new HashSet<SoldItem>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SoldItem> SoldItems { get; set; }
    }
}
