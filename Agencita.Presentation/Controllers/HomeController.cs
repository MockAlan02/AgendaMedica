using Agencita.Presentation.Middlewares;
using Agencita.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agencita.Presentation.Controllers
{
    [ServiceFilter(typeof(ValidateUserSession))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(ILogger<HomeController> logger, ValidateUserSession validateUserSession)
        {
            _logger = logger;
            _validateUserSession = validateUserSession;
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
