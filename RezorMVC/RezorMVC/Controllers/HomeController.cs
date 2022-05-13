using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RezorMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RezorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            RegisterModel registerModel = new RegisterModel()
            {
            };
            return View(registerModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            AboutMeModel aboutMe = new AboutMeModel()
            {
                Forename = model.LastName,
                Surname = model.FirstName
            };

            return View("AboutMe", aboutMe);
        }
        public IActionResult AboutMe()
        {
            AboutMeModel aboutMe = new AboutMeModel()
            {
                Forename = "Marius",
                Surname = "Suiram"

            };
            return View(aboutMe);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
