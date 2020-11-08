using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW6Project.Models;
using Microsoft.EntityFrameworkCore;

namespace HW6Project.Controllers
{
    public class HomeController : Controller
    {
        private ChinookDbContext db;
        public HomeController(ChinookDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Index(string artist)
        {
            ViewBag.returnString = null;
            if(artist == null)
            {
                return View();
            }
            else if(artist.Length < 3)
            {
                ViewBag.returnString = "Please enter more than two characters";
                return View();
            }
            else
            {
                IQueryable<Artist> queryResults = db.Artists.Where(a => a.Name.ToLower().Contains(artist.ToLower()));
                return View(queryResults);
            }
        }
        [HttpGet]
        public IActionResult Artist(int? id)
        {
            Artist artist = db.Artists.Include(art => art.Albums).ThenInclude(alb => alb.Tracks).ThenInclude(g => g.Genre).Single(art => art.ArtistId == id);
            return View(artist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
