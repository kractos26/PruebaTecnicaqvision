using System;
using System.Collections.Generic;

#nullable disable

namespace Travel.Core.Entities
{
    public partial class Libro
    {
        public int LibroIsbn { get; set; }
        public int? EditorialId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Npaginas { get; set; }

        public virtual Editorial Editorial { get; set; }
    }
}
