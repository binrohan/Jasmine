using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class Upazila : BaseEntity
    {
         public int UpazilaId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid DistrictId { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public bool IsVisible { get; set; }
    }
}
