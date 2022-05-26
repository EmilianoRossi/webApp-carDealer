﻿using Microsoft.AspNetCore.Mvc;
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
        public string BrandCar { get; set; }

        [Required(ErrorMessage = "il campo descrizione è obbligatorio")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "il campo prezzo è obbligatorio")]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required(ErrorMessage = "il campo modello è obbligatorio")]
        [StringLength(50)]
        public string ModelCar { get; set; }

        [Required(ErrorMessage = "il campo Chilometri è obbligatorio")]
        [Range(0, int.MaxValue)]
        public int Kilometers  { get; set; }

        public Car()
        {

        }

        public Car(string image, string brandCar, string description, int price, string modelCar, int kilometers)
        {
            this.Image = image;
            this.BrandCar = brandCar;
            this.Description = description;
            this.Price = price;
            this.ModelCar = modelCar;
            this.Kilometers = kilometers;

        }


    }
}