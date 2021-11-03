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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServices _produto;
        private readonly ICategoriaServices _categoria;
        public ProdutoController(IProdutoServices produto, ICategoriaServices categoria)
        {
            this._produto = produto;
            this._categoria = categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAllProdutos()
        {
            var cad = this._categoria.ObterTodos().ToList();
            var prod = this._produto.ObterTodos().ToList();
            return Ok(prod);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosById(int id)
        {
            var cad = this._categoria.ObterTodos().ToList();
            var prod = this._produto.ObterPorId(id);
            List<Produto> lista = new List<Produto>();
            lista.Add(prod);
            return Ok(lista);
        }

        //public async Task<ActionResult<Produto>> PostProdutos(Produto produto)
        [HttpPost]
        public ActionResult<Produto> PostProdutos(Produto produto)
        {
            var listProd = this._produto.Buscar(x => x.Nome.ToUpper().Contains(produto.Nome.ToUpper()));

            if (listProd.Count() <= 0)
            {
                var prod = this._produto.Adicionar(produto);
                List<Produto> lista = new List<Produto>();
                lista.Add(prod);
                return CreatedAtAction("GetProdutosById", new { id = produto.ProdutoId }, lista);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Produto produto)
        {
            var pesquisa = this._produto.Buscar(x => x.Nome.ToUpper().Contains(produto.Nome.ToUpper()) &&
                                                x.ProdutoId != produto.ProdutoId);
            if (pesquisa.Count() > 0)
            {
                return NoContent();
            }
            else
            {
                var prod = this._produto.ObterPorId(id);
                prod.Nome = produto.Nome;
                prod.Preco = produto.Preco;
                prod.CategoriaId = produto.CategoriaId;
                this._produto.Atualizar(prod);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var prod = this._produto.ObterPorId(id);

                this._produto.Remover(prod);
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
    }
}
