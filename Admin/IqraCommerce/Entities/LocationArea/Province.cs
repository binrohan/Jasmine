namespace EBonik.Data.Entities.AddressArea
{
    using IqraBase.Data;
    using IqraBase.Data.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Province")]
    [Alias("province")]
    public class Province : DropDownBaseEntity
    {
        public int AreaId { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public bool IsVisible { get; set; }
    }
}
