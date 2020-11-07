using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models
{
    [Table("PlaylistTrack")]
    public partial class PlaylistTrack
    {
        [Key]
        public long PlaylistId { get; set; }
        [Key]
        public long TrackId { get; set; }

        [ForeignKey(nameof(PlaylistId))]
        [InverseProperty("PlaylistTracks")]
        public virtual Playlist Playlist { get; set; }
        [ForeignKey(nameof(TrackId))]
        [InverseProperty("PlaylistTracks")]
        public virtual Track Track { get; set; }
    }
}
