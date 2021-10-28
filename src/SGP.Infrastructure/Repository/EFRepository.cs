using Microsoft.EntityFrameworkCore;
using SGP.AplicationCore.Interfaces.Repository;
using SGP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGP.Infrastructure.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SgcContext _dbContext;

        public EFRepository(SgcContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual TEntity Adicionar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return _dbContext.Set<TEntity>().Where(predicado).AsEnumerable();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public void Remover(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
