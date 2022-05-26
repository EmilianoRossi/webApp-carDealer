﻿using Microsoft.AspNetCore.Mvc;
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
                Car AddCar = new Car(NewCar.Image, NewCar.BrandCar, NewCar.Description, NewCar.Price, NewCar.ModelCar, NewCar.Kilometers);
                db.Add(AddCar);
                db.SaveChanges();
            }
            return RedirectToAction("IndexAdmin");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            using (CarContext db = new CarContext())
            {
                Car? carToDelete = db.Cars
                     .Where(car => car.Id == id)
                     .FirstOrDefault();

                if (carToDelete != null)
                {
                    db.Cars.Remove(carToDelete);
                    db.SaveChanges();

                    return RedirectToAction("IndexAdmin", "Car");
                }
                else
                {
                    return NotFound();
                }
            }

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
                Car cartoupdate = null;
                using (CarContext db = new CarContext())
                {

                    cartoupdate = db.Cars
                       .Where(Car => Car.Id == id)
                       .First();

                    if (cartoupdate != null)
                    {
                        cartoupdate.Image = model.Image;
                        cartoupdate.BrandCar = model.BrandCar;
                        cartoupdate.Description = model.Description;
                        cartoupdate.Price = model.Price;
                        cartoupdate.ModelCar = model.ModelCar;
                        cartoupdate.Kilometers = model.Kilometers;

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
   
