using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp_carDealer.Data;
using webApp_carDealer.Models;

namespace webApp_carDealer.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarApiController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<Car> cars = new List<Car>();
            using (CarContext db = new CarContext())
            {

                // LOGICA PER RICERCARE I POST CHE CONTENGONO NEL TIUOLO O NELLA DESCRIZIONE LA STRINGA DI RICERCA
                if (search != null && search != "")
                {
                    cars = db.Cars.Where(cars => cars.BrandCar.Contains(search) || cars.ModelCar.Contains(search)).ToList<Car>();
                }
                else
                {
                    cars = db.Cars.ToList<Car>();
                }
            }

            return Ok(cars);
        }
        [HttpGet("{id}")]
        public IActionResult DetailsUser(int id)
        {
            using (CarContext db = new CarContext())
            {
                try
                {

                    Car carFound = db.Cars
                         .Where(cars => cars.Id == id)
                         .First();

                    return Ok(carFound);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("l'auto con " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
    }
    

}
