using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class Color
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Red { get; set; }
        public int? Green { get; set; }
        public int? Blue { get; set; }
    }
}
