namespace EBonik.Data.Entities.AddressArea
{
    using IqraBase.Data;
    using IqraBase.Data.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Upazila")]
    [Alias("upazila")]
    public partial class Upazila : DropDownBaseEntity
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
