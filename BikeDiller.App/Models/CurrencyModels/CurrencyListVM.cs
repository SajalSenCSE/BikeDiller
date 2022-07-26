using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Models.CurrencyModels
{
    public class CurrencyListVM
    {
        public ICollection<Currency> Currencies { get; set; }
    }
}
