﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class OrderDetail
    {
        public string Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public double? Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
