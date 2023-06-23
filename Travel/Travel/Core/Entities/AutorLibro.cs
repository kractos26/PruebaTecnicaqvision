using System;
using System.Collections.Generic;

#nullable disable

namespace Travel.Core.Entities
{
    public partial class AutorLibro
    {
        public int? AutorId { get; set; }
        public int? LibroIsbn { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Libro LibroIsbnNavigation { get; set; }
    }
}
