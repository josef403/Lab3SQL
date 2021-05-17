using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class Airport
    {
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string AirportName { get; set; }
        public string LocationServed { get; set; }
        public string Time { get; set; }
        public string Dst { get; set; }
    }
}
