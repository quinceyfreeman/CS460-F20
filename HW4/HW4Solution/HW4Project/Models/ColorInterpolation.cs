using System;
using System.Collections.Generic;

namespace HW4Project.Models
{
    public class ColorInterpolation
    {
        public string FirstColor {get; set; }
        public string SecondColor { get; set; }
        public int NumberOfColors { get; set; }
        public IEnumerable<string> ColorSet { get; set; }

        public override string ToString()
        {
            return $"First color = {FirstColor}, Second color = {SecondColor}, Number of colors = {NumberOfColors}";
        }
    }
}
