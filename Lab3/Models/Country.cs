using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class Country
    {
        public string Country1 { get; set; }
        public string Region { get; set; }
        public int? Population { get; set; }
        public int? AreaSqMi { get; set; }
        public string PopDensityPerSqMi { get; set; }
        public string CoastlineCoastAreaRatio { get; set; }
        public string NetMigration { get; set; }
        public string InfantMortalityPer1000Births { get; set; }
        public int? GdpPerCapita { get; set; }
        public string Literacy { get; set; }
        public string PhonesPer1000 { get; set; }
        public string Arable { get; set; }
        public string Crops { get; set; }
        public string Other { get; set; }
        public int? Climate { get; set; }
        public string Birthrate { get; set; }
        public string Deathrate { get; set; }
        public string Agriculture { get; set; }
        public string Industry { get; set; }
        public string Service { get; set; }
    }
}
