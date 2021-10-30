using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Repository;
using SGP.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGP.AplicationCore.Services
{
    public class CategoriaService : ICategoriaServices
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public Categoria Adicionar(Categoria entity)
        {
            if (true)
                return _categoriaRepository.Adicionar(entity);
        }

        public void Atualizar(Categoria entity)
        {
            _categoriaRepository.Atualizar(entity);
        }

        public IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicado)
        {
            return _categoriaRepository.Buscar(predicado);
        }

        public Categoria ObterPorId(int id)
        {
            return _categoriaRepository.ObterPorId(id);
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            return _categoriaRepository.ObterTodos();
        }

        public void Remover(Categoria entity)
        {
            _categoriaRepository.Remover(entity);
        }
    }
}
