using System;
using System.Linq;
using System.Web.Mvc;
using ASP_NET_MVC_Entity_Framework_Assignment.Models;
using ASP_NET_MVC_Entity_Framework_Assignment.Data;

namespace ASP_NET_MVC_Entity_Framework_Assignment.Controllers
{
    public class InsureeController : Controller
    {
        private ASPNET_MVC_Entity_Framework_AssignmentContext db =
            new ASPNET_MVC_Entity_Framework_AssignmentContext();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                decimal quote = 50m;

                // AGE
                if (insuree.DateOfBirth.AddYears(18) > DateTime.Now)
                {
                    quote += 100;
                }
                else if (insuree.DateOfBirth.AddYears(25) > DateTime.Now)
                {
                    quote += 50;
                }
                else
                {
                    quote += 25;
                }

                // CAR YEAR
                if (insuree.CarYear < 2000)
                {
                    quote += 25;
                }
                if (insuree.CarYear > 2015)
                {
                    quote += 25;
                }

                // CAR MAKE / MODEL
                if (!string.IsNullOrEmpty(insuree.CarMake) &&
                    insuree.CarMake.ToLower() == "porsche")
                {
                    quote += 25;

                    if (!string.IsNullOrEmpty(insuree.CarModel) &&
                        insuree.CarModel.ToLower() == "911 carrera")
                    {
                        quote += 25;
                    }
                }

                // SPEEDING TICKETS
                quote += insuree.SpeedingTickets * 10;

                // DUI
                if (insuree.DUI)
                {
                    quote *= 1.25m;
                }

                // FULL COVERAGE
                if (insuree.FullCoverage)
                {
                    quote *= 1.5m;
                }

                insuree.Quote = quote;

                db.Insurees.Add(insuree);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Admin
        public ActionResult Admin()
        {
            return View(db.Insurees.ToList());
        }
    }
}
