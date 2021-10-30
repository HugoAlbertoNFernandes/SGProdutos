using Microsoft.AspNetCore.Mvc;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGP.AplicationCore.Interfaces.Services;

namespace SCP.UI.WebAPI.Controllers
{
    [Route("produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    //public class ProdutoController : Controller
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

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
