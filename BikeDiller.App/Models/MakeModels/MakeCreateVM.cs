using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Models.MakeModels
{
    public class MakeCreateVM
    {
        
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
    }
}
