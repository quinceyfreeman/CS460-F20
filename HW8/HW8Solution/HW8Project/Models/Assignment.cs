using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    [Table("Assignment")]
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentTags = new HashSet<AssignmentTag>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ClassID")]
        public int ClassId { get; set; }
        public int Priority { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(512)]
        public string Notes { get; set; }
        [Required]
        [Column("isComplete")]
        public bool IsComplete { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty("Assignments")]
        public virtual Class Class { get; set; }
        [InverseProperty(nameof(AssignmentTag.Assignment))]
        public virtual ICollection<AssignmentTag> AssignmentTags { get; set; }
    }
}
