using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HotKeyScript()
        {
            return PartialView("FormPartials/_HotKeyScriptPartial");
        }

        public IActionResult Preset()
        {
            return PartialView("FormPartials/_PresetScriptPartial");
        }

        public IActionResult Favorite()
        {
            return PartialView("FormPartials/_FavoriteScriptPartial");
        }

        //public IActionResult CreatePresetScript(PresetScriptConfigurationModel model)
        //{
        //    var file = 
        //}
    }
}
