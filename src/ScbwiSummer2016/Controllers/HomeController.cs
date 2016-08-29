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
        public IActionResult Submit([FromBody] RegisterViewModel r)
        {
            var total = 0;

            if (r.member)
            {
                total = 75;
            }
            else
            {
                total = 100;
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

            return Json(new {
                total = total,
                usedcode = usedcode
            });
        }
    }
}
