using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGP.AplicationCore.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaServices _categoriaServices;
        public CategoriaServices(ICategoriaServices categoriaService)
        {
            _categoriaServices = categoriaService;
        }

        public Categoria Adicionar(Categoria entity)
        {
            if (true)
                return _categoriaServices.Adicionar(entity);
        }

        public void Atualizar(Categoria entity)
        {
            _categoriaServices.Atualizar(entity);
        }

        public IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicado)
        {
            return _categoriaServices.Buscar(predicado);
        }

        public Categoria ObterPorId(int id)
        {
            return _categoriaServices.ObterPorId(id);
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            return _categoriaServices.ObterTodos();
        }

        public void Remover(Categoria entity)
        {
            _categoriaServices.Remover(entity);
        }
    }
}
