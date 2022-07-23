using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Models.BikeModels
{
    public class BikeListVM
    {
        public IEnumerable<Bike> Bikes { get; set; }
        public int TotalItem { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
    

    
}
