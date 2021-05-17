using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Lab3.Models
{
    public partial class PlaylistTrack
    {
        [Key]
        [ConcurrencyCheck]
        public int PlaylistId { get; set; }
        [ConcurrencyCheck]
        public int TrackId { get; set; }
        [ConcurrencyCheck]
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
}
