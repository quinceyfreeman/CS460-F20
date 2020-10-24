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
    public class RGBController : Controller
    {
        [HttpGet]
        public IActionResult RGBColor(int? red, int? green, int? blue)
        {
            string hexValue = string.Format("{0:X2}{1:X2}{2:X2}", red, green, blue);
            Debug.WriteLine(hexValue);
            return View("RGBColor", hexValue);
        }
    }
}
