using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4Project.Models;
using System.Drawing;

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
            if(ModelState.IsValid)
            {
                c.ColorSet = ColorList(c);
                Debug.WriteLine("Model is OK");
                return View("ColorInterpolator", c);
            }
            else
            {
                Debug.WriteLine("Model is INVALID");
                return View("ColorInterpolator", c);
            }
        }
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
	        int max = Math.Max(color.R, Math.Max(color.G, color.B));
	        int min = Math.Min(color.R, Math.Min(color.G, color.B));

	        hue = color.GetHue();
	        saturation = (max == 0) ? 0 : 1d - (1d * min / max);
	        value = max / 255d;
        }
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
        public static List<string> ColorList(ColorInterpolation c)
        {
            //create colors from model
            Color firstColor = ColorTranslator.FromHtml(c.FirstColor);
            Color secondColor = ColorTranslator.FromHtml(c.SecondColor);
            //create list and arrays to hold values
            List<string> colorList = new List<string>();
            double[] hue = new double[c.NumberOfColors];
            double[] sat = new double[c.NumberOfColors];
            double[] val = new double[c.NumberOfColors];
            //create variable to hold values of first and second hsv
            double firstColorHue, firstColorSat, firstColorVal;
            double secondColorHue, secondColorSat, secondColorVal;
            ColorToHSV(firstColor, out firstColorHue, out firstColorSat, out firstColorVal);
            ColorToHSV(secondColor, out secondColorHue, out secondColorSat, out secondColorVal);
            //create value steps for hue, sat, and val
            double hueStep = (secondColorHue - firstColorHue) / (c.NumberOfColors - 1);
            double satStep = (secondColorSat - firstColorSat) / (c.NumberOfColors - 1);
            double valStep = (secondColorVal - firstColorVal) / (c.NumberOfColors - 1);
            //fill arrays with values
            for(int i = 0; i < c.NumberOfColors; i++)
            {
                hue[i] = firstColorHue + (hueStep * i);
                sat[i] = firstColorSat + (satStep * i);
                val[i] = firstColorVal + (valStep * i);
            }
            //add individual colors to list
            Color color; string htmlColor;
            for(int i = 0; i < c.NumberOfColors; i++)
            {
                color = ColorFromHSV(hue[i], sat[i], val[i]);
                htmlColor = ColorTranslator.ToHtml(color);
                colorList.Add(htmlColor);        
            }
            return colorList;
        }
    }
}
