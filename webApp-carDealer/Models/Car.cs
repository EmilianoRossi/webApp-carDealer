using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApp_cardDealer.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "il campo immagine è obbligatorio")]
        public string Image { get; set; }

        [Required(ErrorMessage = "il campo marca è obbligatorio")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "il campo descrizione è obbligatorio")]
        [Column(TypeName = "text")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "il campo prezzo è obbligatorio")]
        [Range(0, int.MaxValue)]
        public int Prezzo { get; set; }

        [Required(ErrorMessage = "il campo modello è obbligatorio")]
        [StringLength(50)]
        public string Modello { get; set; }

        [Required(ErrorMessage = "il campo Chilometri è obbligatorio")]
        [Range(0, int.MaxValue)]
        public int Chilometri { get; set; }

        public Car()
        {

        }

        public Car(string Image, string Marca, string Descrizione, int Prezzo, string Modello, int Chilometri)
        {
            this.Image = Image;
            this.Marca = Marca;
            this.Descrizione = Descrizione;
            this.Prezzo = Prezzo;
            this.Modello = Modello;
            this.Chilometri = Chilometri;

        }


    }
}