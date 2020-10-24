using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4Project.Models;

namespace HW4Project.Controllers
{
    public class ColorController : Controller
    {
        [HttpGet]
        public IActionResult ColorInterpolator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ColorInterpolator(ColorInterpolation c)
        {
            Debug.WriteLine(c);
            return View("ColorInterpolator", c);
        }
    }
}
