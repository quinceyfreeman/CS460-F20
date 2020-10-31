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

        public IActionResult List(string sortOrder)
        {
            var assignments = from s in db.Assignments
                              select s;
            switch(sortOrder)
            {
                case "Priority":
                    assignments = assignments.OrderByDescending(s => s.Priority);
                    break;
                case "Due Date":
                    assignments = assignments.OrderBy(s => s.DueDate);
                    break;
                case "Course":
                    assignments = assignments.OrderBy(s => s.Course);
                    break;
                default:
                    assignments = assignments.OrderBy(s => s.Id);
                    break;
            }
            return View("List", assignments);
        }
        public IActionResult Done(long Id)
        {
            Assignments assignment = db.Assignments.Find(Id);
            db.Remove(assignment);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
