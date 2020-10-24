using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HW4Project.Models
{
    public class ColorInterpolation
    {
        [Required]
        [RegularExpression("#[0-9A-F]{6}")]
        public string FirstColor {get; set; }
        [Required]
        [RegularExpression("#[0-9A-F]{6}")]
        public string SecondColor { get; set; }
        [Required]
        public int NumberOfColors { get; set; }
        public IEnumerable<string> ColorSet { get; set; }

        public override string ToString()
        {
            return $"First color = {FirstColor}, Second color = {SecondColor}, Number of colors = {NumberOfColors}";
        }
    }
}
