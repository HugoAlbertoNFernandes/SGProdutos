using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Repository;
using SGP.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGP.AplicationCore.Services
{
    public class ProdutoService : IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Adicionar(Produto entity)
        {
            if (true)
                return _produtoRepository.Adicionar(entity);
        }

        public void Atualizar(Produto entity)
        {
            _produtoRepository.Atualizar(entity);
        }

        public IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado)
        {
            return _produtoRepository.Buscar(predicado);
        }

        public Produto ObterPorId(int id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtoRepository.ObterTodos();
        }

        public void Remover(Produto entity)
        {
            _produtoRepository.Remover(entity);
        }
    }
}
