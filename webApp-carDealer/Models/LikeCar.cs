using System.ComponentModel.DataAnnotations;

namespace webApp_carDealer.Models
{
    public class LikeCar
    {
        [Key]
        public int Id { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }

        public LikeCar()
        {



        }
    }
}
