using System.ComponentModel.DataAnnotations;

namespace webApp_carDealer.Models
{
    public class Buy
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "il campo marca è obbligatorio")]
        [StringLength(50)]
        public string? NameUser { get; set; }
        public int QuantityToBuy { get; set; }
        public int? CarId { get; set; }
        public DateTime? DateBuy { get; set; }
        public Car? Car { get; set; }

        public Buy()
        {


        }
    }
}
