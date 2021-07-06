using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Editar")]
    public class EdicaoController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Alterar")]
        public IActionResult Alterar(IFormCollection form)
        {
            Usuario alterarUsuario = new Usuario();

            alterarUsuario.Nome = form["nome"];
            alterarUsuario.UserName = form["username"];
            alterarUsuario.AtribuirEmail(form["email"]);

            usuarioModel.Alterar(alterarUsuario);

            return LocalRedirect("~/Editar/Index");
        }
    }
}