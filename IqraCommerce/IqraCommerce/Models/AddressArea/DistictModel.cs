using IqraBase.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.AddressArea
{
    [Table("Distict")]
    [Alias("dstct")]
    public partial class DistrictModel
    {
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
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}
