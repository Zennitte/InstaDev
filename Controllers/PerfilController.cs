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
            ViewBag.Post = postModel.Listar();
            return View();
        }
    }
}