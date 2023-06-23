using Travel.Core.Entities;

namespace Travel.Core.Dto
{
    public class LibroDto
    {
        public int LibroIsbn { get; set; }
        public int? EditorialId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Npaginas { get; set; }

        public virtual EditorialDto Editorial { get; set; }
    }
}
