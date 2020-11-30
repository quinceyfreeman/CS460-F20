using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using HW8Project.Models;

#nullable disable

namespace HW8Project.Models
{
    public class ViewModel
    {
        public Assignment Assignment { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public int[] SelectedTags { get; set; }
    }
}