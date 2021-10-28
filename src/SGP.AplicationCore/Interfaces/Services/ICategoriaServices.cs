using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGP.AplicationCore.Interfaces.Services
{
    public interface ICategoriaServices
    {
        Categoria Adicionar(Categoria entity);
        void Atualizar(Categoria entity);
        IEnumerable<Categoria> ObterTodos();
        Categoria ObterPorId(int id);
        IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicado);
        void Remover(Categoria entity);
    }
}
