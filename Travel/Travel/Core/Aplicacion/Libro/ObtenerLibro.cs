using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Threading;
using System;
using Travel.Core.Dto;
using AutoMapper;
using Travel.Repositories;
using System.Collections.Generic;
using System.Linq;
using Travel.Core.Entities;

namespace Travel.Core.Aplicacion.Libro
{
    /// <summary>
    /// Manejo del patron CQRS
    /// </summary>
    public class ObtenerLibro
    {
        /// <summary>
        /// Clase que permite obtener todos los libros
        /// </summary>
        public class ObtenerLibroCommand : IRequest<List<LibroDto>>
        {

        }

        /// <summary>
        /// Se define los encabezados de la respuesta de Libros
        /// </summary>
        public class ObtenerLibroHandler : IRequestHandler<ObtenerLibroCommand, List<LibroDto>>
        {
            private readonly IRepositoryLibro _repositoryLibro;
           
            private readonly IMapper _mapper;
          
            /// <summary>
            /// Constructor de la clase implementa injeccion de dependencias.
            /// </summary>
            /// <param name="repositoryLibro">permite conectar al repositorio de Libros.</param>
            /// <param name="mapper">permite hacer el mapeos entre entidades.</param>
            public ObtenerLibroHandler(IRepositoryLibro repositoryLibro,  IMapper mapper)
            {
                _repositoryLibro = repositoryLibro;
                _mapper = mapper;
               
            }

            /// <summary>
            /// Maneja la solicitud ObtenerLibroCommand y recupera una lista de libros.
            /// </summary>
            /// <param name="request">La solicitud ObtenerLibroCommand.</param>
            /// <param name="cancellationToken">Permite la generación del token</param>
            /// <returns>Una lista de objetos LibroDto.</returns>
            public async Task<List<LibroDto>> Handle(ObtenerLibroCommand request, CancellationToken cancellationToken)
            {
                List<Entities.Libro> libros =  _repositoryLibro.GetAll();
                if (libros.Any())
                {
                    List<LibroDto> libroDto = _mapper.Map<List<Entities.Libro>, List<LibroDto>>(libros);
                   
                    return libroDto;
                }
                throw new Exception("No se encontraron libros");
            }
        }
    }
}
