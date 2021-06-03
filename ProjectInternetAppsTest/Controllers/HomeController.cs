using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectInternetAppsTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Categories()
        //{
        //    return View();
        //}

        //public IActionResult Login()
        //{          
        //    return View();
        //}
        //public IActionResult Cart()
        //{
        //    return View();
        //}
        [Authorize]
        public IActionResult Contact()
        {

            //we should add a post function .... !!!!!!!!!!!!!!!
            //if (HttpContext.Session.GetString("userType") == "User")
            return View();
            //else
            //    return RedirectToAction("login","Users");
        }
        //public IActionResult Pay()
        //{
        //    return View();
        //}
        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        //public IActionResult Category()
        //{
        //    return View();
        //}
        //public IActionResult Manager()
        //{
        //    return View();
        //}

        //public IActionResult Product()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
