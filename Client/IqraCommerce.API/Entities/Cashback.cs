using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Cashback : BaseEntity
    {
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public bool IsPublished { get; set; }
        public double MinOrderValue { get; set; }
        public double Amount { get; set; }
    }
}
