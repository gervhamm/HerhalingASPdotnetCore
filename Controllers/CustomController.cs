using HerhalingASPdotnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace HerhalingASPdotnetCore.Controllers
{
    public class CustomController : Controller
    {
        private readonly ILogger<CustomController> _logger;
        private readonly IOptions<CustomController> _options;
        private readonly IStringLocalizer<CustomController> _localizer;

        public CustomController(ILogger<CustomController> logger, IStringLocalizer<CustomController> localizer, IOptions<CustomController> options)
        {
            _logger = logger;
            _options = options;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            var user = new User()
            {
                Name = "John Doe",
                Email = "test@test.com",
                Message = "Hello World!"
            };
            return View(user);
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View(new User());
        }
        [HttpPost]
        public IActionResult Form(User user)
        {
            //if model is not valid, return the form view with the user object
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return View(user);
        }
    }
}
