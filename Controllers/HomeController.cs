using HerhalingASPdotnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HerhalingASPdotnetCore.Controllers
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

        public IActionResult LoremIpsum()
        {
            return View();
        }
        /// <summary>
        /// SignalR view
        /// </summary>
        /// <returns>SignalR view</returns>
        public IActionResult SignalR()
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
