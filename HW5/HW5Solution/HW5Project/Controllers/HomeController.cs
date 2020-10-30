using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW5Project.Models;

namespace HW5Project.Controllers
{
    public class HomeController : Controller
    {
        private AssignmentsDbContext db;
        public HomeController(AssignmentsDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Assignments assignment)
        {
            if (ModelState.IsValid)
            {
                db.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Confirmation");
            }
            else
            {
                return View(assignment);
            }
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(db.Assignments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
