using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_ShopProject_AP.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]

        public string ProductName { get; set; }
        [Display(Name = "Opis")]
        public string ProductDescription { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage ="Proszę podać dodatnią cenę.")]
        [Display(Name = "Cena label")]
        public decimal Price { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }
    }
}
