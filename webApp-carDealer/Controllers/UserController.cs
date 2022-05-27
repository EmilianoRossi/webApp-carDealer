using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webApp_carDealer.Models;

namespace webApp_carDealer.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult DetailsUser()
        {
            return View("DetailsUser");
        }
    }
}