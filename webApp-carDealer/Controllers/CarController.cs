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

                List<Category> categories = db.Categories.ToList();
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

                Car carToCreate = new Car();
                carToCreate.Image = data.car.Image;
                carToCreate.Description = data.car.Description;
                carToCreate.BrandCar = data.car.BrandCar;
                carToCreate.Price = data.car.Price;
                carToCreate.Kilometers = data.car.Kilometers;
                carToCreate.ModelCar = data.car.ModelCar;
                carToCreate.Like = data.car.Like;
                carToCreate.Quantity = data.car.Quantity;
                carToCreate.CategoryId = data.car.CategoryId;
                db.Cars.Add(carToCreate);
                db.SaveChanges();

            }

            return RedirectToAction("IndexAdmin");

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

        [HttpPost]
        public IActionResult Delete(int id)
        {

            using (CarContext db = new CarContext())
            {

                Car carToDelete = db.Cars
                    .Where(car => car.Id == id)
                    .FirstOrDefault();

                if (carToDelete != null)
                {

                    db.Cars.Remove(carToDelete);
                    db.SaveChanges();

                    return RedirectToAction("IndexAdmin");

                }
                else
                {

                    return NotFound();

                }

            }


        }
        [HttpGet]
        public IActionResult Refile(int id)
        {
            Car CarToUpdate = null;

            using (CarContext db = new CarContext())
            {

                CarToUpdate = db.Cars
                   .Where(car => car.Id == id)
                   .First();
            }
            if (CarToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                return View("Refile", CarToUpdate);
            }

        }
        [HttpPost]
        public IActionResult Refile(int id, Car model)
        {
            if (!ModelState.IsValid)
            {
                return View("Refile", model);
            }
            else
            {
                
                using (CarContext db = new CarContext())
                {
                    Car carToUpdate = db.Cars
                   .Where(car => car.Id == id)
                   .First();
                    carToUpdate = db.Cars
                       .Where(Car => Car.Id == id)
                       .First();

                    if (carToUpdate != null)
                    {
                        
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

    }
}
   
