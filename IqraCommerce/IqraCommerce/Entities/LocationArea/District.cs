namespace EBonik.Data.Entities.AddressArea
{
    using IqraBase.Data;
    using IqraBase.Data.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("District")]
    [Alias("district")]
    public class District : DropDownBaseEntity
    {
        public int DistrictId { get; set; }
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
