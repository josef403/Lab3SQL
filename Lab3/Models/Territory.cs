using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        public int Id { get; set; }
        public string TerritoryDescription { get; set; }
        public int? RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
