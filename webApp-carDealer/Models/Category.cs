using System.ComponentModel.DataAnnotations;

namespace webApp_carDealer.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public string? NameCategory { get; set; }
        //metodo per collegare un entità in relazione 1 n
        public List<Car> Cars { get; set; }

        public Category()
        {



        }

    }
}
