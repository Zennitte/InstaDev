using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        Post postModel = new Post();

        [Route("Listar")]

        public IActionResult Index()
        {

            ViewBag.Perfil = postModel.Listar();
            return View();
        }
    }
}

    //     [Route ("Cadastrar")]

//     // public IActionResult Cadastrar(IFormCollection form){

//     //     Post novoPost = new Post();

//     //     novoPost.UserName = 

//     //     novoPost.G

//     //     // novoPost.Texto = form["Texto"];

//     //     // // novoPost.Imagem = form["Imagem"];

//     //     // if (form.Files.Count > 0)
//     //     // {
//     //     //     var file = form.Files[0];
//     //     //     var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Perfil");

//     //     //     if (!Directory.Exists(folder))
//     //     //     {
//     //     //         Directory.CreateDirectory(folder);
//     //     //     }

//     //     //     var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);


//     //     //     using (var stream = new FileStream (path, FileMode.Create))
//     //     //     {
//     //     //         file.CopyTo(stream);
//     //     //     }

//     //     //     novoPost.Imagem = file.FileName;

//     //     // }
//     //     // else
//     //     // {
//     //     //     novoPost.Imagem = "semimagem.png";
//     //     // }

//     //     postModel.Criar(novoPost);
//     //     ViewBag.Equipes = postModel.Listar();


//     //     return LocalRedirect("~/Perfil/Listar");

//     // }

// }
