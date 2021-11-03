using Microsoft.AspNetCore.Mvc;
using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.UI.WebAPI.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _cliente;
        public ClienteController(IClienteServices cliente)
        {
            this._cliente = cliente;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAllProdutos()
        {
            return Ok(this._cliente.ObterTodos());
        }

        [HttpGet("{email}/{senha}")]
        public ActionResult<IEnumerable<Cliente>> GetLogar(string email, string senha)
        {
            return Ok(this._cliente.Buscar(x=>x.Email.Contains(email) &&
                                            x.Senha.Contains(senha)));
        }
        
    }
}
