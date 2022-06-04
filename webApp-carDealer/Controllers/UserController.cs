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
        public IActionResult RankingCar()
        {
            return View("RankingCar");
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
        public IActionResult UserBuy(int id)
        {
            Car car = null;
            Buy buy = null;
            using (CarContext db = new CarContext())
            {
                car = db.Cars
                   .Where(pacchetto => pacchetto.Id == id)
                   .First();

                buy = db.Buys
                    .Where(buy => buy.CarId == car.Id)
                    .First();

                if (buy == null)
                {

                    return NotFound();

                }
                else
                {

                    return View("UserBuy", buy);
                }

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserBuy(int id, Buy data)
        {

            if (!ModelState.IsValid)
            {
                return View("UserBuy", data);
                

            }
            else
            {

                Car car = null;
                using (CarContext db = new CarContext())
                {

                    car = db.Cars
                       .Where(Car => Car.Id == id)
                       .First();
                    if (car != null)
                    {

                        Buy BuyToCreate = new Buy();
                        BuyToCreate.NameUser = data.NameUser;
                        BuyToCreate.QuantityToBuy = data.QuantityToBuy;
                        BuyToCreate.DateBuy = DateTime.Now;


                        BuyToCreate.CarId = car.Id;
                        db.Buys.Add(BuyToCreate);
                        db.SaveChanges();
                        return RedirectToAction("RecapBuy");
                    }
                    else
                    {

                        return NotFound();
                    }

                }
            }
        }
        
    }
  }