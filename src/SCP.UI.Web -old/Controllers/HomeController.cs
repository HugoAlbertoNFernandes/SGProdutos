using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCP.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using SGP.AplicationCore.Entity;
using Microsoft.AspNetCore.Http;
using SCP.UI.Web.Repository;

namespace SCP.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Cliente cli)
        {
            if (cli.Email != null || cli.Senha != null)
            {

                var repo = new ClienteRepository("http://localhost:8085/cliente",
                                            cli.Email.ToString(),
                                            cli.Senha.ToString());

                var _task = repo.GetLoginAsync();
                var vCliente = _task.Result.FirstOrDefault();
                
                if (vCliente != null)
                {
                    HttpContext.Session.SetString("Nome", vCliente.Nome);
                    HttpContext.Session.SetString("Id", vCliente.ClienteId.ToString());

                    return RedirectToAction("Index", "Produto"); 
                }
                else
                {
                    ViewBag.Message = "Usuário ou senha inválido!";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Usuário ou senha inválido!";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
