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

        [HttpGet]
        public IActionResult RankingCar()
        {
            List <CarRanking> carRankings = new List<CarRanking>();
            
            using (CarContext db = new CarContext())
            {
                //Auto piu vendute
                var queryClassifica = (from buy in db.Buys
                                       
                                       group buy by buy.CarId
                                       
                                          into tableGroup
                                       
                                       select new { tableGroup.Key, Count = tableGroup.Count() }).ToList();
                                          

                List<Car> cars = db.Cars.ToList<Car>();

                
                foreach (Car car in cars)
                {

                    CarRanking carRanking= new CarRanking();
                    carRanking.CarId = car.Id;
                    int indexCar = queryClassifica.FindIndex(c => c.Key == car.Id);
                    
                    if (indexCar > -1)

                    {
                        carRanking.CarSell = queryClassifica[indexCar].Count;
                       
                    }
                    else
                    {

                        carRanking.CarSell = 0 ;

                    }
                    carRanking.CarBrand = car.BrandCar;
                    carRanking.CarModel = car.ModelCar;
                    carRanking.ImageCar = car.Image;

                    
                    carRankings.Add(carRanking);
                    
                }

            }
            return Ok(carRankings.OrderByDescending(x=>x.CarSell));
        }

        [HttpPost]
        public IActionResult Post([FromBody] LikeCar model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            using (CarContext context = new CarContext())
            {
                
                Car carFound = context.Cars
                         .Where(cars => cars.Id == model.Id)
                         .First();
                
               
                carFound.Like++;

                context.SaveChanges();



                return Ok(carFound);
            }
        }
    }

    
}
