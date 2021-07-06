using System.Collections.Generic;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set;}
        Usuario usuarioModel = new Usuario();

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> UsuariosCSV = usuarioModel.LerTodasLinhasCSV("Database/usuario.csv");

            var logado = UsuariosCSV.Find(x => x.Split(";")[2] == form["email"] && x.Split(";")[3] == form["senha"]);

            if (logado != null)
            {
                HttpContext.Session.SetString("_username", logado.Split(";")[0]);
                return LocalRedirect("~/Perfil/Index");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login/Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_username");
            return LocalRedirect("~/Login/Index");
        }
    }
}