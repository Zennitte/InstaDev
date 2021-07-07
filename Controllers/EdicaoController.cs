using System;
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
            ViewBag.Usuarios = usuarioModel.Listar();
            ViewBag.UserName = HttpContext.Session.GetString("_Username");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");
            ViewBag.Email = HttpContext.Session.GetString("_Email");
            ViewBag.Senha = HttpContext.Session.GetString("_Senha");
            ViewBag.IdUsuario = HttpContext.Session.GetString("_IdUsuario");
            return View();
        }

        [Route("Alterar")]
        public IActionResult Alterar(IFormCollection form)
        {
            Usuario alterarUsuario = new Usuario();

            alterarUsuario.Nome = form["nome"];
            alterarUsuario.UserName = form["username"];
            alterarUsuario.AtribuirEmail(form["email"]);
            alterarUsuario.AtribuirId(Int32.Parse(HttpContext.Session.GetString("_IdUsuario")));
            alterarUsuario.AtribuirSenha(HttpContext.Session.GetString("_Senha"));

            usuarioModel.Alterar(alterarUsuario);

            return LocalRedirect("~/Editar/Index");
        }

        [Route("Deletar")]
        public IActionResult Deletar(int id)
        {
            int usuarioDeletado = Int32.Parse(HttpContext.Session.GetString("_IdUsuario"));
            
            usuarioModel.Deletar(usuarioDeletado);
            ViewBag.Usuarios = usuarioModel.Listar();

            return LocalRedirect("~/Login/Index");
        }
    }
}