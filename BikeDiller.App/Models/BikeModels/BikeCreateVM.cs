using BikeDiller.App.Helpers;
using BikeDiller.EntityModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Models.BikeModels
{
    public class BikeCreateVM
    {

    
        [RegularExpression("^[1-9]*$",ErrorMessage ="Select Make")]
        public int MakeId { get; set; }


        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Bike Model")]
        public int ModelId { get; set; }

        [Required]
        [GetYearRange(2000, ErrorMessage = "Year between 2000 and CurrentYear")]
        public int Year { get; set; }


        [Required(ErrorMessage ="Provide Bike MileAge")]
        [Range(1,int.MaxValue,ErrorMessage ="Number")]
        public int Mileage { get; set; }


        public string Features { get; set; }


        [Required (ErrorMessage ="Provide SellerName")]
        public string SellerName { get; set; }


        [Required(ErrorMessage ="Required ")]
        [EmailAddress(ErrorMessage ="Provide Valid Info")]
        public string SellerEmail { get; set; }


        [Required(ErrorMessage = "Provide SellerPhone")]
        [Range(1, int.MaxValue, ErrorMessage = "Number")]
        public string SellerPhone { get; set; }


        [Required(ErrorMessage = "Provide Bike Price")]
        [Range(1, int.MaxValue, ErrorMessage = "Number")]
        public int Price { get; set; }


        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Currency ")]
        public int CurrencyId { get; set; }


        public IFormFile ImagePathFile { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Make> Makes { get; set; }

        public IEnumerable<Currency> Currenies { get; set; }

        

    }


}
