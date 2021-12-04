using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Genre
    {
        public Genre()
        {
            GenreContents = new HashSet<GenreContent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GenreContent> GenreContents { get; set; }
    }
}
