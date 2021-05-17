using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class GameOfThrone
    {
        public int Episode { get; set; }
        public int? EpisodeInSeason { get; set; }
        public int? Season { get; set; }
        public string Title { get; set; }
        public string DirectedBy { get; set; }
        public string WrittenBy { get; set; }
        public DateTime? OriginalAirDate { get; set; }
        public double? USViewersMillions { get; set; }
    }
}
