using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Season
    {
        public Season()
        {
            Episodes = new HashSet<Episode>();
        }

        public int Id { get; set; }
        public int TotalEpisodes { get; set; }
        public int NSeasons { get; set; }
        public DateTime Release { get; set; }
        public int? SerieId { get; set; }

        public virtual Serie Serie { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
