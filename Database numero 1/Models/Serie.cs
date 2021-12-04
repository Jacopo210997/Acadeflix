using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Serie
    {
        public Serie()
        {
            Contents = new HashSet<Content>();
            Seasons = new HashSet<Season>();
        }

        public int Id { get; set; }
        public int TotalSeason { get; set; }
        public int TotalEpisodes { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
    }
}
