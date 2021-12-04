using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Catalog
    {
        public Catalog()
        {
            ContentsCatalogues = new HashSet<Content>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ContentsCatalogue> ContentsCatalogues { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
