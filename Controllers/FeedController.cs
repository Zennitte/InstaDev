using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using InstaDev.Models;

namespace InstaDev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        Post postModel = new Post();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Posts = postModel.Listar();
            return View();
        }

        // [Route("Cadastrar")]
        // public IActionResult Cadastrar(IFormCollection form)
        // {
        //     Post novoPost = new Post();
        //     novoPost.Texto = form["Texto"];

        //     //Upload Inicio

        //     if (form.Files.Count > 0)
        //     {
        //         var file = form.Files[0];
        //         var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Post");

        //         if (!Directory.Exists(folder))
        //         {
        //             Directory.CreateDirectory(folder);
        //         }

        //         var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

        //         using (var stream = new FileStream(path, FileMode.Create))
        //         {
        //             file.CopyTo(stream);
        //         }

        //         novoPost.Imagem = file.FileName;
        //     }

        //     //Upload Final

        //     postModel.Criar(novoPost);

        //     ViewBag.Posts = postModel.Listar();

        //     return LocalRedirect("~/Post/Listar");
        // }


        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {

            Post novoPost = new Post();

            novoPost.Texto = form["Texto"];

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