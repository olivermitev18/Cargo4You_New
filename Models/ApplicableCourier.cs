using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cargo4You.Models
{
    public class ApplicableCourier {

		public ApplicableCourier() { }

		public ApplicableCourier(string applicableName, double applicableCost) {
			ApplicableName = applicableName;
			ApplicableCost = applicableCost;
		}

		public string ApplicableName { get; set; }
		public double ApplicableCost { get; set; }
	}
}