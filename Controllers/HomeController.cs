<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> 9f4528782e7480e6aa972a61ebd8eb3249b45443
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
<<<<<<< HEAD
// using InstaDev.Models;
=======
using InstaDev.Models;
>>>>>>> 9f4528782e7480e6aa972a61ebd8eb3249b45443

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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

<<<<<<< HEAD
=======
        
>>>>>>> 9f4528782e7480e6aa972a61ebd8eb3249b45443
    }
}
