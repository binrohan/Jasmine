using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.PromotionalArea
{
    [Table("Coupon")]
    [Alias("cpn")]
    public partial class CouponModel : AppBaseModel
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
    public partial class CouponCheckModel : AppBaseModel
    {
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }
        public string CouponCode { get; set; }
        public double CoupenAmount { get; set; }
        public double OrderAmount { get; set; }
        public double OrderDiscount { get; set; }
        /// <summary>
        /// Pending|Applied
        /// </summary>
        public string Status { get; set; } = "Pending";
        /// <summary>
        /// This Activity will come when checked for CouponAmount.
        /// Device Activity
        /// </summary>
        public Guid ActivityId { get; set; }
    }
}
