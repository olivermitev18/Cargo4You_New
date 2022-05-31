using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Cargo4You.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cargo4You.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult AddServiceBasedOnDimensions() {
			return PartialView("ServiceBasedOnDimensionsRow", new ServiceBasedOnDimension());
		}

		[HttpPost]
		public ActionResult Index(Order order) {
			if (!ModelState.IsValid)
			{
				return View("Index");
			}

			var result = new ApplicableCourier();
			if (order != null) {
				var applicableCouriers = new List<ApplicableCourier>();
				var volume = order.Width * order.Height * order.Depth;

				foreach (var courier in (List<Courier>)TempData["Couriers"]) {
					var applicableServiceBasedOnDimension = courier.ServicesBasedOnDimensions.FirstOrDefault(service => service.DimensionFrom <= volume && service.DimensionTo >= volume);
					var applicableServiceBasedOnWeight = courier.ServicesBasedOnWeight.FirstOrDefault(service => service.WeightFrom <= order.Weight && service.WeightTo >= order.Weight);
					if (applicableServiceBasedOnDimension != null && applicableServiceBasedOnWeight != null) {
						applicableCouriers.Add(applicableServiceBasedOnDimension.DimensionCost > applicableServiceBasedOnWeight.WeightCost
							? new ApplicableCourier(courier.Name, applicableServiceBasedOnDimension.DimensionCost)
							: new ApplicableCourier(courier.Name, applicableServiceBasedOnWeight.WeightCost));
					}
					if (applicableServiceBasedOnDimension != null && applicableServiceBasedOnWeight == null) applicableCouriers.Add(new ApplicableCourier(courier.Name, applicableServiceBasedOnDimension.DimensionCost));
					if (applicableServiceBasedOnDimension == null && applicableServiceBasedOnWeight != null) applicableCouriers.Add(new ApplicableCourier(courier.Name, applicableServiceBasedOnWeight.WeightCost));
				}

				result = applicableCouriers.First(courier => courier.ApplicableCost == applicableCouriers.Max(ac => ac.ApplicableCost));
			}

			return RedirectToAction("PackagePrice", result);
		}

		public ActionResult PackagePrice() {
			ViewBag.Message = "Your application description page.";
			return View();
		}

		public ActionResult Courier() { return View(); }

        [HttpPost]
        public ActionResult Courier(Courier courier) {
			if (!ModelState.IsValid)
			{
				return View("Courier");
			}

			var couriers = new List<Courier>();
			if (TempData["Couriers"] != null) couriers.AddRange((List<Courier>)TempData["Couriers"]);

			if (courier != null) {
				courier.ServicesBasedOnDimensions = (List<ServiceBasedOnDimension>)TempData["ServicesBasedOnDimension"];
				courier.ServicesBasedOnWeight = (List<ServiceBasedOnWeight>)TempData["ServicesBasedOnWeight"];
				couriers.Add(courier);
				TempData["Couriers"] = couriers;

				TempData["ServicesBasedOnDimension"] = new List<ServiceBasedOnDimension>();
				TempData["ServicesBasedOnWeight"] = new List<ServiceBasedOnWeight>();
				TempData["CourierMessage"] = "You have added a new Courier!";
			}

			return RedirectToAction("Courier");
		}

		public ActionResult ServiceBasedOnDimensionsRow(ServiceBasedOnDimension service) {
			if (!ModelState.IsValid)
			{
				return View("Courier");
			}

			var services = new List<ServiceBasedOnDimension>();
			if (TempData["ServicesBasedOnDimension"] != null) services.AddRange((List<ServiceBasedOnDimension>)TempData["ServicesBasedOnDimension"]);

			if (service != null) {
				services.Add(service);
				TempData["ServicesBasedOnDimension"] = services;
				TempData["DimensionsMessage"] = "You have added a based on dimensions!";
			}

			return RedirectToAction("Courier");
		}

		public ActionResult ServiceBasedOnWeightRow(ServiceBasedOnWeight serviceBasedOnWeight) {
			if (!ModelState.IsValid)
			{
				return View("Courier");
			}

			var services = new List<ServiceBasedOnWeight>();
			if (TempData["ServicesBasedOnWeight"] != null) services.AddRange((List<ServiceBasedOnWeight>)TempData["ServicesBasedOnWeight"]);
			if(serviceBasedOnWeight != null) {
				services.Add(serviceBasedOnWeight);
				TempData["ServicesBasedOnWeight"] = services;
				TempData["WeightMessage"] = "You have added a based on weight!";
			}

			return RedirectToAction("Courier");
		}
	}
}