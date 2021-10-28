using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Repository;
using SGP.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGP.AplicationCore.Services
{
    public class ClienteService : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente entity)
        {
            if (true)
                return _clienteRepository.Adicionar(entity);
        }

        public void Atualizar(Cliente entity)
        {
            _clienteRepository.Atualizar(entity);
        }

        public IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicado)
        {
            return _clienteRepository.Buscar(predicado);
        }

        public IEnumerable<Cliente> Logar(string email, string passord)
        {
            return Buscar(x => x.Email.Contains(email) &&
                                x.Senha.Contains(passord));
        }

        public Cliente ObterPorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Cliente entity)
        {
            _clienteRepository.Remover(entity);
        }
    }
}
