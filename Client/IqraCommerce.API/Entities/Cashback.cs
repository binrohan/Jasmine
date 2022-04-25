﻿using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Cashback : BaseEntity
    {
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public bool IsPublished { get; set; }
        public bool IsLimited { get; set; }
        public int Redeemed { get; set; }
        public int Count { get; set; }
        public double MinOrderValue { get; set; }
        public double MaxDiscount { get; set; }
        public double MinDiscount { get; set; }
        public double Discount { get; set; }
    }
}
