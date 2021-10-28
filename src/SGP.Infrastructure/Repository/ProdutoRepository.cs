using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Repository;
using SGP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Infrastructure.Repository
{
    public class ProdutoRepository : EFRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(SgcContext dbContext) : base(dbContext)
        {

        }
    }
}
