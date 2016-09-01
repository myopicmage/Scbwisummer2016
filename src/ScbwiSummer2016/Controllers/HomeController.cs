using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScbwiSummer2016.Models;

namespace ScbwiSummer2016.Controllers
{
    public class HomeController : Controller
    {
        private ScbwiContext db;

        public HomeController(ScbwiContext db)
        {
            this.db = db;
        }

        public IActionResult Index() => View();
        public IActionResult Locations() => Json(db.locations.ToList());
        
        [HttpPost]
        public IActionResult Calculate([FromBody] RegisterViewModel r) => Json(GenTotal(r));

        [HttpPost]
        public IActionResult Submit([FromBody] RegisterViewModel r)
        {
            var totals = GenTotal(r);

            var registration = new Registration
            {
                address1 = r.address1,
                address2 = r.address2,
                firstname = r.firstname,
                lastname = r.lastname,
                city = r.city,
                state = r.state,
                codeused = r.codeused,
                email = r.email,
                location = db.locations.SingleOrDefault(x => x.id == r.locationid),
                member = r.member,
                phone = r.phone,
                total = totals.total,
                subtotal = totals.subtotal,
                zip = r.zip,
                cleared = new DateTime(2000, 1, 1),
                paid = new DateTime(2000, 1, 1),
                created = DateTime.Now,
            };

            db.registrations.Add(registration);
            db.SaveChanges();

            return Json(new
            {
                totals.total,
                paypalid = registration.PayPalId,
            });
        }

        private TotalResult GenTotal(RegisterViewModel r)
        {
            var total = 0;
            var subtotal = 0;

            if (r.member)
            {
                total = 75;
                subtotal = 75;
            }
            else
            {
                total = 100;
                subtotal = 75;
            }

            var usedcode = false;

            if (r.codeused != null)
            {
                if (r.codeused.ToLower() == "i am asking nicely")
                {
                    total = 0;
                    usedcode = true;
                }
                else if (r.codeused.ToLower() == "yes i know the muffin man")
                {
                    total = total / 2;
                    usedcode = true;
                }
            }

            return new TotalResult(total, subtotal, usedcode);
        }

        class TotalResult
        {
            public decimal total { get; set; }
            public decimal subtotal { get; set; }
            public bool usedcode { get; set; }

            public TotalResult(decimal total, decimal subtotal, bool usedcode)
            {
                this.total = total;
                this.subtotal = subtotal;
                this.usedcode = usedcode;
            }
        }
    }
}
