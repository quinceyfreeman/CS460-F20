using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expeditions.Models
{
    [Table("Expedition")]
    public partial class Expedition
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string Season { get; set; }
        [Column(TypeName = "INT")]
        public int? Year { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "NVARCHAR(80)")]
        public string TerminationReason { get; set; }
        [Column(TypeName = "BOOLEAN")]
        public bool OxygenUsed { get; set; }
        [Column("PeakID", TypeName = "INT")]
        public int? PeakId { get; set; }
        [Column("TrekkingAgencyID", TypeName = "INT")]
        public int? TrekkingAgencyId { get; set; }

        [ForeignKey(nameof(PeakId))]
        [InverseProperty("Expeditions")]
        public virtual Peak Peak { get; set; }
        [ForeignKey(nameof(TrekkingAgencyId))]
        [InverseProperty("Expeditions")]
        public virtual TrekkingAgency TrekkingAgency { get; set; }
    }
}
