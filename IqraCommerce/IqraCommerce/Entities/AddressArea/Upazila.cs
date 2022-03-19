namespace EBonik.Data.Entities.AddressArea
{
    using IqraBase.Data;
    using IqraBase.Data.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Upazila")]
    [Alias("upzl")]
    public partial class Upazila
    {
        public int Id { get; set; }
        /// <summary>
        /// AreaId is Used to calculate Relationship.
        /// Because Sometime Id Column is auto created.
        /// </summary>
        public int AreaId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}
