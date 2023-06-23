using System;
using System.Collections.Generic;

#nullable disable

namespace Travel.Core.Entities
{
    
    public partial class Autor
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
