using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeDiller.EntityModels
{
    public class Make
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
