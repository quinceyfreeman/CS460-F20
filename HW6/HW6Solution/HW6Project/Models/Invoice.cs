using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        [Key]
        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        [Required]
        [Column(TypeName = "DATETIME")]
        public byte[] InvoiceDate { get; set; }
        [Column(TypeName = "NVARCHAR(70)")]
        public string BillingAddress { get; set; }
        [Column(TypeName = "NVARCHAR(40)")]
        public string BillingCity { get; set; }
        [Column(TypeName = "NVARCHAR(40)")]
        public string BillingState { get; set; }
        [Column(TypeName = "NVARCHAR(40)")]
        public string BillingCountry { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string BillingPostalCode { get; set; }
        [Required]
        [Column(TypeName = "NUMERIC(10,2)")]
        public byte[] Total { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Invoices")]
        public virtual Customer Customer { get; set; }
        [InverseProperty(nameof(InvoiceLine.Invoice))]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
