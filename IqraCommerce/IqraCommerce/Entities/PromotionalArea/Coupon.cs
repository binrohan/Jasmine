using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.PromotionalArea
{
    [Table("Coupon")]
    [Alias("cpn")]
    public partial class Coupon : AppBaseEntity
    {
        public string CouponCode { get; set; }
        /// <summary>
        /// Percentage||FixedAmount
        /// </summary>
        public string DiscountType { get; set; }
        public double CoupenAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
