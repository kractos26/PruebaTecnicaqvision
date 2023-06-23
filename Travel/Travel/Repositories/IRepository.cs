using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Travel.Repositories
{
    /// <summary>
    /// Interfaz genérica para el repositorio que define las operaciones comunes.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene todos los elementos del repositorio.
        /// </summary>
        /// <returns>Una lista de elementos de tipo T.</returns>
        List<T> GetAll();

        /// <summary>
        /// Busca elementos en el repositorio que cumplan con el predicado especificado.
        /// </summary>
        /// <param name="predicado">El predicado de búsqueda.</param>
        /// <returns>Una lista de elementos de tipo T que cumplen con el predicado.</returns>
        List<T> Buscar(Expression<Func<T, bool>> predicado);

        /// <summary>
        /// Trae el primer elemento del repositorio que cumple con el predicado especificado.
        /// </summary>
        /// <param name="predicado">El predicado de búsqueda.</param>
        /// <returns>El primer elemento de tipo T que cumple con el predicado.</returns>
        T TraerUno(Expression<Func<T, bool>> predicado);

        /// <summary>
        /// Trae el último elemento del repositorio que cumple con el predicado especificado.
        /// </summary>
        /// <param name="predicado">El predicado de búsqueda.</param>
        /// <returns>El último elemento de tipo T que cumple con el predicado.</returns>
        T TraerUltimo(Expression<Func<T, bool>> predicado);

        /// <summary>
        /// Adiciona una entidad al repositorio.
        /// </summary>
        /// <param name="Entidad">La entidad a adicionar.</param>
        /// <returns>La entidad adicionada.</returns>
        T Adicionar(T Entidad);

        /// <summary>
        /// Modifica una entidad en el repositorio.
        /// </summary>
        /// <param name="Entidad">La entidad a modificar.</param>
        /// <returns>La entidad modificada.</returns>
        T Modificar(T Entidad);

        /// <summary>
        /// Elimina una entidad del repositorio.
        /// </summary>
        /// <param name="Entidad">La entidad a eliminar.</param>
        /// <returns>La entidad eliminada.</returns>
        T Eliminar(T Entidad);

        /// <summary>
        /// Guarda los cambios realizados en el repositorio.
        /// </summary>
        void Guardar();
    }

}
