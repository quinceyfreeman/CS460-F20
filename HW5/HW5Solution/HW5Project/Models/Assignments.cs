using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW5Project.Models
{
    public partial class Assignments
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        public long Priority { get; set; }
        [Required]
        [Column(TypeName = "DATETIME")]
        public byte[] DueDate { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(10)")]
        public string Course { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(64)")]
        public string Title { get; set; }
        [Column(TypeName = "NVARCHAR(512)")]
        public string Notes { get; set; }
    }
}
