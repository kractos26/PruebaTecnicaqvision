using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Travel.Core.Context;
using Travel.Core.Entities;

namespace Travel.Repositories
{
    public class RepositoryLibro : IRepositoryLibro
    {
        private readonly IRepository<Libro> _repocitorio;


        public RepositoryLibro(IRepository<Libro> _repository)
        {
            _repocitorio = _repository;
           
        }

        public Libro Adicionar(Libro Libro)
        {

            this._repocitorio.Adicionar(Libro);
            this._repocitorio.Guardar();
            return Libro;
        }

        public List<Libro> Buscar(Expression<Func<Libro, bool>> predicado)
        {
            return this._repocitorio.Buscar(predicado);
        }


        public Libro Eliminar(Libro Entidad)
        {
            this._repocitorio.Eliminar(Entidad);
            this._repocitorio.Guardar();
            return Entidad;
        }

        public List<Libro> GetAll()
        {
            return this._repocitorio.GetAll();
        }

        public void Guardar()
        {
            this._repocitorio.Guardar();
        }

        public Libro Modificar(Libro Entidad)
        {
            this._repocitorio.Modificar(Entidad);
            this._repocitorio.Guardar();
            return Entidad;
        }

        public Libro TraerUltimo(Expression<Func<Libro, bool>> predicado)
        {
            return this._repocitorio.TraerUltimo(predicado);
        }

        public Libro TraerUno(Expression<Func<Libro, bool>> predicado)
        {
            return this._repocitorio.TraerUno(predicado);

        }
    }
}
