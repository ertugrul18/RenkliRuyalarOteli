﻿using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.WebMvcUI.Models;
using System.Diagnostics;

namespace RenkliRuyalarOteli.WebMvcUI.Controllers
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
            /*
             * 
             * 
             * */

            return Redirect("https://www.google.com");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}