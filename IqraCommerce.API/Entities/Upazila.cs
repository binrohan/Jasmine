using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Upazila
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public double Xmax { get; set; }
        public double Xmin { get; set; }
        public double Ymax { get; set; }
        public double Ymin { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}
