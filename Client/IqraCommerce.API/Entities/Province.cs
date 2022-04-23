using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class Province : BaseEntity
    {
        
        public int AreaId { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public bool IsVisible { get; set; }
    }
}
