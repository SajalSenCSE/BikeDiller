using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Models.MakeModels
{
    public class MakeListVM
    {
        public ICollection<Make> List { get; set; }
    }
}
