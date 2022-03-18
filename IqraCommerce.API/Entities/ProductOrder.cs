using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ProductOrder
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid CustomerId { get; set; }
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
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public double ShippingCharge { get; set; }
        public string From { get; set; }
        public int FileCount { get; set; }
        public string IconPath { get; set; }
        public bool AutoOrderIsActive { get; set; }
        public Guid ConfirmedBy { get; set; }
        public DateTime ConfirmedAt { get; set; }
        public string StatusChangeReason { get; set; }
    }
}
