using Microsoft.AspNetCore.Mvc;
using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.UI.WebAPI.Controllers
{
    [Route("produtos")]
    [ApiController]
    public class ProdutoController  : ControllerBase
    {
        private readonly IProdutoServices _produto;
        public ProdutoController(IProdutoServices produto)
        {
            this._produto = produto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAllProdutos()
        {
            //var produtoItens = this._produto.ObterTodos();
            return Ok(this._produto.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosById(int id)
        {
            return Ok(this._produto.ObterPorId(id));
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
