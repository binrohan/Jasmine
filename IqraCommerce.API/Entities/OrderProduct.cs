using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class OrderProduct : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid RefProductId { get; set; }
        
        public string DisplayName { get; set; }
        public string PackSize { get; set; }
        public double CurrentPrice { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountedPercentage { get; set; }
    }
}
