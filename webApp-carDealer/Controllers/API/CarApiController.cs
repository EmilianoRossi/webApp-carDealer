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
        
    }
}
