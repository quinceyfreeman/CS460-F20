using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    public partial class AssignmentTag
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AssignmentID")]
        public int? AssignmentId { get; set; }
        [Column("TagID")]
        public int? TagId { get; set; }

        [ForeignKey(nameof(AssignmentId))]
        [InverseProperty("AssignmentTags")]
        public virtual Assignment Assignment { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("AssignmentTags")]
        public virtual Tag Tag { get; set; }
    }
}
