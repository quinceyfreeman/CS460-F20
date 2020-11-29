using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    [Table("Class")]
    public partial class Class
    {
        public Class()
        {
            Assignments = new HashSet<Assignment>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Assignment.Class))]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
