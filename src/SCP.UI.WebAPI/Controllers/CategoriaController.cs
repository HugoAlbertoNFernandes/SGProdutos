using Microsoft.AspNetCore.Mvc;
using SGP.AplicationCore.Entity;
using SGP.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.UI.WebAPI.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServices _categoria;

        public CategoriaController(ICategoriaServices categoria)
        {
            this._categoria = categoria;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAllCategorias()
        {
            var cad = this._categoria.ObterTodos().ToList();
            return Ok(cad);
        }
    }
}
