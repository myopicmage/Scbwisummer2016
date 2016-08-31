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
        public IActionResult Calculate([FromBody] RegisterViewModel r)
        {
            return Json(GenTotal(r));
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

            return new TotalResult
            {
                total = total,
                usedcode = usedcode,
                subtotal = subtotal
            };
        }

        class TotalResult
        {
            public decimal total { get; set; }
            public decimal subtotal { get; set; }
            public bool usedcode { get; set; }
        }
    }
}
