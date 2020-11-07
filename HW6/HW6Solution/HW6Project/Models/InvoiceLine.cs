using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models
{
    [Table("InvoiceLine")]
    public partial class InvoiceLine
    {
        [Key]
        public long InvoiceLineId { get; set; }
        public long InvoiceId { get; set; }
        public long TrackId { get; set; }
        [Required]
        [Column(TypeName = "NUMERIC(10,2)")]
        public byte[] UnitPrice { get; set; }
        public long Quantity { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoiceLines")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey(nameof(TrackId))]
        [InverseProperty("InvoiceLines")]
        public virtual Track Track { get; set; }
    }
}
