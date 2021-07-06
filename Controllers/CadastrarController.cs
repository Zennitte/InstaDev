using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Usuario")]
    public class CadastrarController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [Route("Index")]
        public IActionResult Index(){
            ViewBag.Usuarios = usuarioModel.Listar();
            return View();
        }

        [Route("Cadastrar")] 
        public IActionResult Cadastrar(IFormCollection form){

            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome= form["nome"];
            novoUsuario.UserName=form["nick"];
            novoUsuario.AtribuirEmail(form["email"]);
            novoUsuario.AtribuirSenha(form["senha"]);
            novoUsuario.AtribuirId();

            usuarioModel.Cadastrar(novoUsuario);
            ViewBag.Usuarios = usuarioModel.Listar();

            return LocalRedirect("~/Login/Index");
        }

    }
}