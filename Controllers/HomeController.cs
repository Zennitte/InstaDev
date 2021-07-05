using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstaDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return LocalRedirect("~/Login/Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
    }
}
