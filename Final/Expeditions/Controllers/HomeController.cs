using Expeditions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Expeditions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExpeditionDbContext dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ExpeditionDbContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        public IActionResult Index()
        {
            var peaks = dbContext.Peaks.Include(e => e.Expeditions).OrderByDescending(h => h.Height).Take(15);
            return View(peaks);
        }
        public IActionResult Stats()
        {
            var data = new {
                expeditions = dbContext.Expeditions.Count(),
                peakCount = dbContext.Peaks.Count(),
                notClimbed = dbContext.Peaks.Where(p => p.ClimbingStatus == false).Count()
            };
            return Json(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
