

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Travel.Core.Context;

namespace Travel.Repositories
{
    /// <summary>
    /// Implementación genérica de un repositorio que proporciona métodos básicos para trabajar con entidades de tipo T.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad con el que trabaja el repositorio.</typeparam>

    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly TravelContext _contex;

        /// <summary>
        /// Crea una nueva instancia de la clase Repository.
        /// </summary>
        /// <param name="contex">Contexto de viaje utilizado para acceder a la base de datos.</param>
        public Repository(TravelContext contex)
        {
            this._contex = contex;
        }

        /// <summary>
        /// Adiciona una entidad al repositorio.
        /// </summary>
        /// <param name="Entidad">Entidad a ser adicionada.</param>
        /// <returns>La entidad adicionada.</returns>
        public T Adicionar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State != EntityState.Deleted)
            {
                this._contex.Entry<T>(Entidad).State = EntityState.Added;
            }
            else
            {
                this._contex.Set<T>().Add(Entidad);
            }
            return Entidad;
        }

        /// <summary>
        /// Busca entidades que cumplan con un predicado dado.
        /// </summary>
        /// <param name="predicado">Predicado para la búsqueda de entidades.</param>
        /// <returns>Una lista de entidades que cumplen con el predicado.</returns>
        public List<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _contex.Set<T>().Where(predicado).ToList();
        }

        /// <summary>
        /// Libera los recursos utilizados por el repositorio y el contexto de viaje.
        /// </summary>
        public void Dispose()
        {
            _contex.Dispose();
        }

        /// <summary>
        /// Elimina una entidad al repositorio.
        /// </summary>
        /// <param name="Entidad">Entidad a ser eliminada.</param>
        /// <returns>La entidad adicionada.</returns>
        public T Eliminar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State == EntityState.Deleted)
            { this._contex.Set<T>().Attach(Entidad); }
            _contex.Entry<T>(Entidad).State = EntityState.Deleted;
            return Entidad;
        }

        /// <summary>
        /// Obtine todos los elementos 
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return _contex.Set<T>().ToList();
        }

        /// <summary>
        /// Guarda los cambios realizados en el repositorio en la base de datos.
        /// </summary>
        public void Guardar()
        {
            this._contex.SaveChanges();
        }

        /// <summary>
        /// Modifica una entidad al repositorio.
        /// </summary>
        /// <param name="Entidad">Entidad a ser modificada.</param>
        /// <returns>La entidad adicionada.</returns>
        public T Modificar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State == EntityState.Deleted)
            { this._contex.Set<T>().Attach(Entidad); }

            _contex.Entry<T>(Entidad).State = EntityState.Modified;

            return Entidad;
        }

        /// <summary>
        /// Busca entidad que cumpl con un predicado dado trayendo el primer elemento.
        /// </summary>
        /// <param name="predicado">Predicado para la búsqueda de entidades.</param>
        /// <returns>Una lista de entidades que cumplen con el predicado.</returns>
        public T TraerUno(Expression<Func<T, bool>> predicado)
        {
            return _contex.Set<T>().FirstOrDefault(predicado);
        }

        /// <summary>
        /// Busca entidad que cumpl con un predicado dado trayendo el ultimo elemento elemento.
        /// </summary>
        /// <param name="predicado">Predicado para la búsqueda de entidades.</param>
        /// <returns>Una lista de entidades que cumplen con el predicado.</returns>
        public T TraerUltimo(Expression<Func<T, bool>> predicado)
        {
            return _contex.Set<T>().LastOrDefault(predicado);
        }
    }
}