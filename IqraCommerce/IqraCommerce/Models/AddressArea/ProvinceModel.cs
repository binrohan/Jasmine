using System;

namespace EBonik.Data.Models.AddressArea
{
    class ProvinceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ChangeLog { get; set; }
        public int AreaId { get; set; }
        public byte Type { get; set; }
        public byte[] Geometry { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}
