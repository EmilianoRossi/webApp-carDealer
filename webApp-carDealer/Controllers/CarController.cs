using Microsoft.AspNetCore.Mvc;
using webApp_cardDealer.Models;
using webApp_carDealer.Data;

namespace webApp_carDealer.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car NewCar)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", NewCar);
            }
            using (CarContext db = new CarContext())
            {
                Car AddCar = new Car();
                db.Add(AddCar);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
