using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class Element
    {
        public int Number { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int? Period { get; set; }
        public int? Group { get; set; }
        public double? Mass { get; set; }
        public int? Radius { get; set; }
        public int? Valenceel { get; set; }
        public int? Stableisotopes { get; set; }
        public double? Meltingpoint { get; set; }
        public double? Boilingpoint { get; set; }
        public double? Density { get; set; }
    }
}
