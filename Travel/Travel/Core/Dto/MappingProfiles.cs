using AutoMapper;
using Travel.Core.Entities;

namespace Travel.Core.Dto
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Libro, LibroDto>();
            CreateMap<Editorial, EditorialDto>();

        }
    }
}
