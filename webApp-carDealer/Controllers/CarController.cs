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
        public IActionResult ListCar()
        {

            List<Car> listCars = new List<Car>(); 

            using (CarContext db = new CarContext())
            {

                listCars = db.Cars.ToList<Car>();

            }
            return View("ListaViaggi", listCars);


        }

    }
}
