using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScbwiSummer2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScbwiSummer2016.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ScbwiContext db;

        public ManageController(ScbwiContext ctx)
        {
            db = ctx;
        }

        public IActionResult Index() => View();
        public IActionResult Dump() => Json(db.registrations.ToList());
    }
}