using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cargo4You.Models
{
    public class Order
    {
        [Required(ErrorMessage = "The Width field is required")]
        [Display(Name = "Width")]
        public double Width { get; set; }

        [Required(ErrorMessage = "The Height field is required")]
        [Display(Name = "Height")]
        public double Height { get; set; }

        [Required(ErrorMessage = "The Depth field is required")]
        [Display(Name = "Depth")]
        public double Depth { get; set; }

        [Required(ErrorMessage = "The Weight field is required")]
        [Display(Name = "Weight")]
        public double Weight { get; set; }
    }
}