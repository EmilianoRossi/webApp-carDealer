using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webApp_carDealer.Data;
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

        public IActionResult RecapBuy()
        {
            return View("RecapBuy");
        }

        [HttpGet]
        public IActionResult UserBuy()
        {
            using (CarContext db = new CarContext())
            {

                List<Car> car = db.Cars.ToList();
                CarsBuy model = new CarsBuy();
                model.buy = new Buy();
                model.listCar = car;
                return View("UserBuy", model);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserBuy(CarsBuy data)
        {

            if (!ModelState.IsValid)
            {
                using (CarContext db = new CarContext())
                {

                    List<Car> car = db.Cars.ToList();
                    data.listCar = car;

                }
                return View("UserBuy", data);

            }

            using (CarContext db = new CarContext())
            {

                Buy BuyToCreate = new Buy();
                BuyToCreate.QuantityToBuy = data.buy.QuantityToBuy;
                BuyToCreate.NameUser = data.buy.NameUser;
                BuyToCreate.DateBuy = DateTime.Now;
                BuyToCreate.CarId = data.buy.CarId;
                db.Buys.Add(BuyToCreate);
                db.SaveChanges();

            }

            return RedirectToAction("RecapBuy");

        }
    }
}