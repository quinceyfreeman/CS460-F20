using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expeditions.Models
{
    [Table("Peak")]
    public partial class Peak
    {
        public Peak()
        {
            Expeditions = new HashSet<Expedition>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(30)")]
        public string Name { get; set; }
        [Column(TypeName = "INT")]
        public int Height { get; set; }
        [Required]
        [Column(TypeName = "BOOLEAN")]
        public bool ClimbingStatus { get; set; }
        [Column(TypeName = "INT")]
        public int? FirstAscentYear { get; set; }

        [InverseProperty(nameof(Expedition.Peak))]
        public virtual ICollection<Expedition> Expeditions { get; set; }
    }
}
