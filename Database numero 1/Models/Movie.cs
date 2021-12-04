using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Contents = new HashSet<Content>();
            MovieActors = new HashSet<MovieActor>();
        }

        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public int? DirectorId { get; set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
