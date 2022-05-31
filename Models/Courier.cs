using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cargo4You.Models
{
    public class Courier {
		public Courier() {
			this.ServicesBasedOnDimensions = new List<ServiceBasedOnDimension>();
			this.ServicesBasedOnWeight = new List<ServiceBasedOnWeight>();
		}

		[Required(ErrorMessage = "The Courier name field is required")]
		[Display(Name = "CourierName")]
		[StringLength(50)]
		public string Name { get; set; }

		public List<ServiceBasedOnDimension> ServicesBasedOnDimensions;
		public List<ServiceBasedOnWeight> ServicesBasedOnWeight;
    }
}