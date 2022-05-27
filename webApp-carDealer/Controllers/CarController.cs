using Microsoft.AspNetCore.Mvc;
using webApp_carDealer.Models;
using webApp_carDealer.Data;

namespace webApp_carDealer.Controllers
{
    public class CarController : Controller
    {


        [HttpGet]
        public IActionResult IndexAdmin()
        {

            List<Car> listCar = new List<Car>();

            using (CarContext db = new CarContext())
            {

                listCar = db.Cars.ToList<Car>();

            }
            return View("IndexAdmin", listCar);

        }

        [HttpGet]
        public IActionResult Create()
        {
            using (CarContext db = new CarContext())
            {

                List<Category> categories = db.Categories.ToList<Category>();   
                CarsCategories model = new CarsCategories();
                model.car = new Car();
                model.categories = categories;
                return View("Form", model);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarsCategories data)
        {

            if (!ModelState.IsValid)
            {
                using (CarContext db = new CarContext())
                {

                    List<Category> categories = db.Categories.ToList();
                    data.categories = categories;

                }
                return View("Form", data);

            }

            using (CarContext db = new CarContext())
            {

                Car CarToCreate = new Car();
                CarToCreate.BrandCar = data.car.BrandCar;
                CarToCreate.ModelCar = data.car.ModelCar;
                CarToCreate.Kilometers = data.car.Kilometers;
                CarToCreate.Quantity = data.car.Quantity;
                CarToCreate.Description = data.car.Description;
                CarToCreate.Image = data.car.Image;
                CarToCreate.Price = data.car.Price;
                CarToCreate.CategoryId = data.car.CategoryId;
                db.Add(CarToCreate);
                db.SaveChanges();

            }

            return RedirectToAction("IndexAdmin", "Car");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Car CarToUpdate = null;

            using (CarContext db = new CarContext())
            {

                CarToUpdate = db.Cars
                   .Where(pacchetto => pacchetto.Id == id)
                   .First();
            }
            if (CarToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                return View("Update", CarToUpdate);
            }

        }
        [HttpPost]
        public IActionResult Update(int id, Car model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }
            else
            {
                Car carToUpdate = null;
                using (CarContext db = new CarContext())
                {

                    carToUpdate = db.Cars
                       .Where(Car => Car.Id == id)
                       .First();

                    if (carToUpdate != null)
                    {
                        carToUpdate.Image = model.Image;
                        carToUpdate.BrandCar = model.BrandCar;
                        carToUpdate.Description = model.Description;
                        carToUpdate.Price = model.Price;
                        carToUpdate.ModelCar = model.ModelCar;
                        carToUpdate.Kilometers = model.Kilometers;
                        carToUpdate.Quantity = model.Quantity;

                        db.SaveChanges();

                        return RedirectToAction("IndexAdmin");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }
        
        [HttpGet]
        
        public IActionResult Details(int id)
        {
            Car carFound = null;

            using (CarContext db = new CarContext())
            {

                carFound = db.Cars
                   .Where(Car => Car.Id == id)
                   .First();
            }
            if (carFound != null)
            {
                return View("Details", carFound);
            }
            else
            {
                return NotFound("la macchina con id" + id + " non è stato trovato");
            }

        }
    }
}
   
