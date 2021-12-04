using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int? CatalogsId { get; set; }

        public virtual Catalog Catalogs { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
