using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        readonly string url = "http://localhost:23089/produtos";
        readonly string urlCategoria = "http://localhost:23089/categorias";

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

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                var repoCateg = new CategoriasRepository(urlCategoria);
                var _taskCateg = repoCateg.GetAllCategoriaAsync();
                var categ = _taskCateg.Result;

                var repo = new ProdutosRepository(this.url);
                var _task = repo.GetAllProdutoAsync();
                var prod = _task.Result;

                if (prod == null)
                {
                    return NotFound();
                }

                if (categ != null)
                    ViewBag.Categorias = categ;
                else
                    ViewBag.Categorias = new Categoria();

                if (!String.IsNullOrEmpty(searchString))
                {
                    return View(prod.Where(x => x.Nome.ToUpper().Contains(searchString.ToUpper()) ||
                                                    x.Categorias.Descricao.ToUpper().Contains(searchString.ToUpper())));
                }
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
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                var repoCateg = new CategoriasRepository(urlCategoria);
                var _taskCateg = repoCateg.GetAllCategoriaAsync();
                var categ = _taskCateg.Result;

                if (categ != null)
                    ViewBag.Categorias = categ;
                else
                    ViewBag.Categorias = new Categoria();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Produto produto)
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                if (ModelState.IsValid)
                {
                    var repo = new ProdutosRepository(this.url + "/");
                    var _task = repo.PostProdutoAsync(produto);
                    var prod = _task.Result;
                    if (prod == null)
                    {
                        ViewBag.Erro = "Produto já cadastrado. Tente Alterar o Produto";
                        return View(produto);
                    }
                    else
                        return RedirectToAction("Index");
                }
                var repoCateg = new CategoriasRepository(urlCategoria);
                var _taskCateg = repoCateg.GetAllCategoriaAsync();
                var categ = _taskCateg.Result;

                if (categ != null)
                    ViewBag.Categorias = categ;
                else
                    ViewBag.Categorias = new Categoria();

                return View(produto);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                var repoCateg = new CategoriasRepository(urlCategoria);
                var _taskCateg = repoCateg.GetAllCategoriaAsync();
                var categ = _taskCateg.Result;

                var repo = new ProdutosRepository(this.url + "/" + id.ToString());
                var _task = repo.GetAllProdutoAsync();
                var prod = _task.Result;

                if (prod == null)
                {
                    return NotFound();
                }

                if (categ != null)
                    ViewBag.Categorias = categ;
                else
                    ViewBag.Categorias = new Categoria();

                return View(prod.FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto)
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                var repo = new ProdutosRepository(this.url + "/" + produto.ProdutoId.ToString());
                var _task = repo.PutProdutoAsync(produto);
                var prod = _task.Result;

                if (prod == "No Content")
                {
                    var repoCateg = new CategoriasRepository(urlCategoria);
                    var _taskCateg = repoCateg.GetAllCategoriaAsync();
                    var categ = _taskCateg.Result;

                    if (categ != null)
                        ViewBag.Categorias = categ;
                    else
                        ViewBag.Categorias = new Categoria();


                    ViewBag.Erro = "Já exite um produto com este nome.";
                    return View(produto);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
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
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (HttpContext.Session.GetString("Nome") != null && HttpContext.Session.GetString("Id") != null)
            {
                HttpClient cliente = new HttpClient();
                cliente.DeleteAsync(this.url + "/" + Convert.ToInt32(id));
                var _task = cliente.DeleteAsync(this.url + "/" + Convert.ToInt32(id));
                var prod = _task.Result;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}


