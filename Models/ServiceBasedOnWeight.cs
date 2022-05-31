using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cargo4You.Models
{
    public class ServiceBasedOnWeight {
		[Required(ErrorMessage = "The Weight from field is required")]
        [Display(Name = "Weight from")]
        public int WeightFrom { get; set; }

		[Required(ErrorMessage = "The Weight to field is required")]
		[Display(Name = "Weight to")]
		public int WeightTo { get; set; }

		[Required(ErrorMessage = "The Costs field is required")]
        [Display(Name = "Cost")]
        public double WeightCost { get; set; }
    }
}