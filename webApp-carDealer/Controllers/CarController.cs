using Microsoft.AspNetCore.Mvc;

namespace webApp_carDealer.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
