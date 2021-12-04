using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Director
    {
        public Director()
        {
            Episodes = new HashSet<Episode>();
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
