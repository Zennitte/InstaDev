using System;
using System.Collections.Generic;
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
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");
            ViewBag.Perfil = postModel.ListarPosts(Int32.Parse(HttpContext.Session.GetString("_IdUsuario")));
           

            return View();
        }
    }
}