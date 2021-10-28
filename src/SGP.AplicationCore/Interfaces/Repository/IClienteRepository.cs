using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.AplicationCore.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> Logar(string email, string passord);
    }
}
