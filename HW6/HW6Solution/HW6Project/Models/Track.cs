using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models
{
    [Table("Track")]
    public partial class Track
    {
        public Track()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        [Key]
        public long TrackId { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(200)")]
        public string Name { get; set; }
        public long? AlbumId { get; set; }
        public long MediaTypeId { get; set; }
        public long? GenreId { get; set; }
        [Column(TypeName = "NVARCHAR(220)")]
        public string Composer { get; set; }
        public long Milliseconds { get; set; }
        public long? Bytes { get; set; }
        [Required]
        [Column(TypeName = "NUMERIC(10,2)")]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty("Tracks")]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Tracks")]
        public virtual Genre Genre { get; set; }
        [ForeignKey(nameof(MediaTypeId))]
        [InverseProperty("Tracks")]
        public virtual MediaType MediaType { get; set; }
        [InverseProperty(nameof(InvoiceLine.Track))]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        [InverseProperty(nameof(PlaylistTrack.Track))]
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
