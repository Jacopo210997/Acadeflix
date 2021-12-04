using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Content
    {
        public Content()
        {
            ContentsCatalogues = new HashSet<ContentsCatalogue>();
            Favorites = new HashSet<Favorite>();
            GenreContents = new HashSet<GenreContent>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public int? SerieId { get; set; }
        public int? MovieId { get; set; }
        public string Dtype { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Serie Serie { get; set; }
        public virtual ICollection<ContentsCatalogue> ContentsCatalogues { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<GenreContent> GenreContents { get; set; }
    }
}
