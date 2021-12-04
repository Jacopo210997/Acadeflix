using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Episode
    {
        public Episode()
        {
            EpActors = new HashSet<EpActor>();
        }

        public int Id { get; set; }
        public string NameEpisodes { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Release { get; set; }
        public int? SeasonId { get; set; }
        public int? DirectorId { get; set; }

        public virtual Director Director { get; set; }
        public virtual Season Season { get; set; }
        public virtual ICollection<EpActor> EpActors { get; set; }
    }
}
