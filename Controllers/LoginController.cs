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

            var logado = UsuariosCSV.Find(x => x.Split(";")[2] == form["Email"] && x.Split(";")[3] == form["Senha"]);

            if (logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                HttpContext.Session.SetString("_Nome", logado.Split(";")[0]);
                HttpContext.Session.SetString("_Email", logado.Split(";")[2]);
                HttpContext.Session.SetString("_Senha", logado.Split(";")[3]);
                HttpContext.Session.SetString("_IdUsuario", logado.Split(";")[4]);
                return LocalRedirect("~/Feed/Listar");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login/Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/Login/Index");
        }
    }
}