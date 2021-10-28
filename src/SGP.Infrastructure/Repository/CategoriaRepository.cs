using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Repository;
using SGP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Infrastructure.Repository
{
    public class CategoriaRepository : EFRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SgcContext dbContext) : base(dbContext)
        {

        }
    }
}
