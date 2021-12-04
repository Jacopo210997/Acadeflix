using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Actor
    {
        public Actor()
        {
            EpActors = new HashSet<Episode>();
            MovieActors = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Episode> EpActors { get; set; }
        public virtual ICollection<Movie> MovieActors { get; set; }
    }
}
