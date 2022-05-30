using System.ComponentModel.DataAnnotations;

namespace webApp_carDealer.Models
{
    public class Refile
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public string NameSupplier { get; set; }
        public DateTime dateTime { get; set; }
        public int PriceRefile { get; set; }
        //metodo per collegare un entità in relazione 1 n
        public int Quantity { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }
        
        
        public Refile()
        {


        }

        
    }
}
