using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Repository;
using SGP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SgcContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Cliente> Logar(string email, string passord)
        {
            return Buscar(x => x.Email.Contains(email) &&
                                x.Senha.Contains(passord));
        }
    }
}
