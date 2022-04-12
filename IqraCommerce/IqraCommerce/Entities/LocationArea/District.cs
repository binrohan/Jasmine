namespace EBonik.Data.Entities.AddressArea
{
    using IqraBase.Data;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("District")]
    [Alias("district")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// AreaId is Used to calculate Relationship.
        /// Because Sometime Id Column is auto created.
        /// </summary>
        public int AreaId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public double ChargeAmount { get; set; }
        /// <summary>
        /// if OrderAmount is greater than or equal to MaxAmount, then ShippingCharge will be MinChargeAmount.
        /// </summary>
        public double MaxAmount { get; set; }
        /// <summary>
        /// Applicable when OrderAmount is greater than or equal to MaxAmount
        /// </summary>
        public double MinChargeAmount { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}
