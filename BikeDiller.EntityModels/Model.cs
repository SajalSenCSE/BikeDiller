using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeDiller.EntityModels
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Make Make { get; set; }
        public int MakeId { get; set; }
    }
}
