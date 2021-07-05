using InstaDev.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        Post post = new Post();
        Usuario user = new Usuario();

    

        [Route ("ListarUsuario")]

        public IActionResult Index()
        {

            ViewBag.Perfil = post.Listar();
            return View();
        }


        public IActionResult 
    }
}