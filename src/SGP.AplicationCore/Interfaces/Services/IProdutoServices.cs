using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGP.AplicationCore.Interfaces.Services
{
    public interface IProdutoServices
    {
        Produto Adicionar(Produto entity);
        void Atualizar(Produto entity);
        IEnumerable<Produto> ObterTodos();
        Produto ObterPorId(int id);
        IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado);
        void Remover(Produto entity);
    }
}
