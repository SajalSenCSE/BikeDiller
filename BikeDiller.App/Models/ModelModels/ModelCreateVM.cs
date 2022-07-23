using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Models.ModelModels
{
    public class ModelCreateVM
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Bike Model")]
        public int MakeId { get; set; }

        public ICollection<Make> Makes { get; set; }
    }
}
