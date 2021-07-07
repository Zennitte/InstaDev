using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using InstaDev.Models;
using System;

namespace InstaDev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        Post postModel = new Post();

        Usuario usuarioModel = new Usuario();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");
            ViewBag.Posts = postModel.Listar();
            return View();
        }


        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {

            Post novoPost = new Post();

            novoPost.Texto = form["Texto"];

            novoPost.IdUsuario = Int32.Parse(HttpContext.Session.GetString("_IdUsuario"));

            novoPost.UserName = HttpContext.Session.GetString("_UserName");

            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            // novoPost.UserName = ViewBag.Usuarios.Find;

            novoPost.AtrubuirIdPost();

            // novoPost.Imagem = form["Imagem"];

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Feed");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novoPost.Imagem = file.FileName;

            }
            else
            {
                novoPost.Imagem = "semimagem.png";
            }

            postModel.Criar(novoPost);
            ViewBag.Posts = postModel.Listar();


            return LocalRedirect("~/Feed/Listar");

        }
    }
}