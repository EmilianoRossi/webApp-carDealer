using System.ComponentModel.DataAnnotations;

namespace webApp_carDealer.Models
{
    public class Buy
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "il campo marca è obbligatorio")]
        [StringLength(50)]
        public string? BrandCarBuy { get; set; }      
        public string? ModelCarBuy { get; set; }
        public int? CarId { get; set; }
        public DateTime? DateBuy { get; set; }
        public Car? Car { get; set; }

        public Buy()
        {


        }
    }
}
