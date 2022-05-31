using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cargo4You.Models
{
    public class ServiceBasedOnDimension {
		[Required(ErrorMessage = "The Dimension from field is required")]
        [Display(Name = "Dimension from")]
        public int DimensionFrom { get; set; }

		[Required(ErrorMessage = "The Dimension To field is required")]
		[Display(Name = "Dimension to")]
		public int DimensionTo { get; set; }

		[Required(ErrorMessage = "The Costs field is required")]
        [Display(Name = "Cost")]
        public double DimensionCost { get; set; }
    }
}