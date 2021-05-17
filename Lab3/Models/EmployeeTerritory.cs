using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class EmployeeTerritory
    {
        public string Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
