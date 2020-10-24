using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HW4Project.Models
{
    public class ColorInterpolation
    {
        [Required]
        public string FirstColor {get; set; }
        [Required]
        public string SecondColor { get; set; }
        [Required]
        [Range(2,Int32.MaxValue)]
        public int NumberOfColors { get; set; }
        public IEnumerable<string> ColorSet { get; set; }

        public override string ToString()
        {
            return $"First color = {FirstColor}, Second color = {SecondColor}, Number of colors = {NumberOfColors}";
        }
    }
}
