using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BikeDiller.App.Models.BikeModels
{
    public class BikeEditVM:BikeCreateVM
    {
        public int Id { get; set; }
        
    }
}
