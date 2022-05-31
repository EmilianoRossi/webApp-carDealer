using Microsoft.AspNetCore.Mvc;
using webApp_carDealer.Models;
using webApp_carDealer.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace webApp_carDealer.Controllers
{
    public class CarController : Controller
    {


        [HttpGet]
        public IActionResult IndexAdmin()
        {

            using (CarContext db = new CarContext())
            {

                var queryDisponibilità = (from refile in db.Refiles
                                          group refile by refile.CarId
                            into tableGroup
                                          select new { tableGroup.Key, Sum = tableGroup.Sum(refile => refile.Quantity) }).ToList();

                List<Car> cars = db.Cars.ToList<Car>();

                List<CarsAvailable> carsAvailables = new List<CarsAvailable>();
                foreach (Car car in cars)
                {

                    CarsAvailable carsAvailable = new CarsAvailable();
                    carsAvailable.CarId = car.Id;
                    int indexCar = queryDisponibilità.FindIndex(c => c.Key == car.Id);
                    if (indexCar > -1)
                    {
                        carsAvailable.QuantityAvailable = queryDisponibilità[indexCar].Sum;

                    }
                    else
                    {

                        carsAvailable.QuantityAvailable = 0;

                    }
                    carsAvailable.ImageCar = car.Image;
                    carsAvailable.BrandCar = car.BrandCar;
                    carsAvailable.ModelCar = car.ModelCar;


                    carsAvailables.Add(carsAvailable);




                }

                //List<Refile> refile = db.Refiles.ToList<Refile>();
                //.Where(refile=> refile.CarId )
                return View("IndexAdmin", carsAvailables);

            }

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

        [HttpPost]
        public IActionResult Delete(int id)
        {

            using (CarContext db = new CarContext())
            {
                Car? carToDelete = db.Cars
                     .Where(car => car.Id == id)
                     .FirstOrDefault();
                Refile? refileToDelete = db.Refiles
                    .Where(refile => refile.CarId == id)
                    .FirstOrDefault();
                Buy? buyToDelete = db.Buys
                    .Where(buy => buy.CarId == id)
                    .FirstOrDefault();
                if (carToDelete != null && refileToDelete!=null && buyToDelete!=null)
                {
                    db.Cars.Remove(carToDelete);
                    db.Refiles.Remove(refileToDelete);
                    db.Buys.Remove(buyToDelete);
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
        [HttpGet]
        public IActionResult Refile()
        {
            using (CarContext db = new CarContext())
            {

                List<Car> car = db.Cars.ToList();
                CarsRefiles model = new CarsRefiles();
                model.refile = new Refile();
                model.listCar = car;
                return View("Refile", model);

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Refile(CarsRefiles data)
        {

            if (!ModelState.IsValid)
            {
                using (CarContext db = new CarContext())
                {

                    List<Car> car = db.Cars.ToList();
                    data.listCar = car;

                }
                return View("Refile", data);

            }

            using (CarContext db = new CarContext())
            {

                Refile RefileToCreate = new Refile();
                RefileToCreate.NameSupplier = data.refile.NameSupplier;
                RefileToCreate.Quantity = data.refile.Quantity;
                RefileToCreate.dateTime = DateTime.Now;


                RefileToCreate.CarId = data.refile.CarId;
                db.Refiles.Add(RefileToCreate);
                db.SaveChanges();

            }

            return RedirectToAction("IndexAdmin");

        }
        [HttpGet]
        public IActionResult ListRefile()
        {

            using (CarContext db = new CarContext())
            {
                //Query totale disponibilità
                var queryDisponibilità = (from refile in db.Refiles
                                          group refile by refile.CarId
                            into tableGroup
                                          select new { tableGroup.Key, Sum = tableGroup.Sum(refile => refile.Quantity) }).ToList();

                //Query acquisto
                var queryBuy = (from buy in db.Buys
                                group buy by buy.CarId
                                into tableGroup2
                                select new { tableGroup2.Key, Sum = tableGroup2.Sum(buy => buy.QuantityToBuy) }).ToList();

                List<Car> cars = db.Cars.ToList<Car>();

                List<CarsAvailable> carsAvailables = new List<CarsAvailable>();
                foreach (Car car in cars)
                {

                    CarsAvailable carsAvailable = new CarsAvailable();
                    carsAvailable.CarId = car.Id;
                    int indexCar = queryDisponibilità.FindIndex(c => c.Key == car.Id);
                    int indexBuy = queryBuy.FindIndex(x => x.Key == car.Id);
                    if (indexCar > -1 && indexBuy > -1)

                    {
                        carsAvailable.QuantityAvailable = queryDisponibilità[indexCar].Sum;

                        carsAvailable.QuantityAvailable -= queryBuy[indexBuy].Sum;

                    }
                    else
                    {

                        carsAvailable.QuantityAvailable = queryDisponibilità[indexCar].Sum; ;

                    }
                    carsAvailable.BrandCar = car.BrandCar;
                    carsAvailable.ModelCar = car.ModelCar;


                    carsAvailables.Add(carsAvailable);

                }

                return View("ListRefile", carsAvailables);

            }
        }

    }





}
