using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    public partial class Tag
    {
        public Tag()
        {
            AssignmentTags = new HashSet<AssignmentTag>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; }

        [InverseProperty(nameof(AssignmentTag.Tag))]
        public virtual ICollection<AssignmentTag> AssignmentTags { get; set; }
    }
}
