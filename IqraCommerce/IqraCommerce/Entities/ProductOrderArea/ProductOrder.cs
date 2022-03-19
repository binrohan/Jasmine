using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductOrderArea
{
    [Table("ProductOrder")]
    [Alias("pdctodr")]
    public partial class ProductOrder : AppBaseEntity
    {
        public Guid CustomerId { get; set; }
        /// <summary>
        /// CoupenId is a CouponHistoryId
        /// </summary>
        public Guid CouponId { get; set; }
        public string OrderNo { get; set; }
        public double TotalItem { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalAmount { get; set; }
        public double PayableAmount { get; set; }
        public double PaidAmount { get; set; }
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public double DiscountTotal { get; set; }
        public double CouponDiscount { get; set; }
        public double CashBack { get; set; }
        public string PromoCode { get; set; }
        /// <summary>
        /// Online|CashOnDelivery
        /// </summary>
        public string PaymentMethod { get; set; }
        /// <summary>
        /// Initiated|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|
        /// </summary>
        public string Status { get; set; }
        public double ShippingCharge { get; set; }
        /// <summary>
        /// Request Order|Order Now| Cart Order
        /// </summary>
        public string From { get; set; }
        public int FileCount { get; set; }
        public string IconPath { get; set; }
        public bool AutoOrderIsActive { get; set; }
        public Guid ConfirmedBy { get; set; }
        public DateTime ConfirmedAt { get; set; }
        public string StatusChangeReason { get; set; }
    }
}
