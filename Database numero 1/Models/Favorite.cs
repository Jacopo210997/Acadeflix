using System;
using System.Collections.Generic;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? ContentsId { get; set; }

        public virtual Content Contents { get; set; }
        public virtual User Users { get; set; }
    }
}
