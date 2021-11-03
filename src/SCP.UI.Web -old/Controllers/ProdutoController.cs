using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCP.UI.Web.Repository;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SCP.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        readonly string url = "http://localhost:8085/produtos";
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                var repo = new ProdutosRepository(url);
                var _task = repo.GetAllProdutoAsync();
                var prod = _task.Result;
                return View(prod);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Produto produto)
        {
            if (ModelState.IsValid)
            {
                var repo = new ProdutosRepository(this.url +"/");

                var _task = repo.PostProdutoAsync(produto);
                var prod = _task.Result;
                if (prod.Count > 0)

                { return RedirectToAction("Index"); }
                else
                    return View(produto);
                    
            }
            return View(produto);
        }

        public IActionResult Edit()
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return View();
            }                
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var repo = new ProdutosRepository(this.url + "/" + id.ToString());

                var _task = repo.GetAllProdutoAsync();
                var prod = _task.Result;


                if (prod == null)
                {
                    return NotFound();
                }

                return View(prod[0]);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var repo = new ProdutosRepository(this.url + "/" + Convert.ToInt32(id.ToString()));

            var _task = repo.GetAllProdutoAsync();
            var prod = _task.Result;

            if (prod == null)
            {
                return NotFound();
            }
            return View(prod[0]);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {

            HttpClient cliente = new HttpClient();

            var _url = this.url + "/" + Convert.ToInt32(id);

            cliente.DeleteAsync(_url);


            //var repo = new ProdutosRepository(this.url + "/" + id.ToString());

            //var _task = repo.DeleteProdutoAsync();
            //var prod = _task.Result;

            return RedirectToAction("Index");
        }
    }
}


