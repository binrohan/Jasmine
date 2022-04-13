using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class District : BaseEntity
    {
        public Guid ProvinceId { get; set; }
        public double ShippingCharge { get; set; }
        public double LowerBounderForMinShippingCharge { get; set; }
        public double MinShippingCharge { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public bool IsVisible { get; set; }
    }
}
