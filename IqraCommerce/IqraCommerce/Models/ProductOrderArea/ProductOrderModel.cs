using EBonik.Data.Models.PromotionalArea;
using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.ProductOrderArea
{
    [Table("ProductOrder")]
    [Alias("pdctodr")]
    public partial class ProductOrderModel : AppBaseModel
    {
        /// <summary>
        /// CoupenId is a CouponHistoryId
        /// </summary>
        public Guid CouponId { get; set; }
        public string OrderNo { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ReferenceId { get; set; }
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
        /// Online||CashOnDelivery
        /// </summary>
        public string PaymentMethod { get; set; }
        /// <summary>
        /// Pending|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|Returned
        /// </summary>
        public string Status { get; set; } = "Pending";
        public double ShippingCharge { get; set; }
        /// <summary>
        /// Request Order|Order Now| Cart Order
        /// </summary>
        public string From { get; set; }
        public int FileCount { get; set; }
        public string IconPath { get; set; }
        public string Remarks { get; set; }
        public int DistrictId { get; set; }
        public Guid AddressId { get; set; }
        public List<ProductOrderItemModel> Items { get; set; }
        //public OrderPaymentModel Payment { get; set; }
        /// <summary>
        /// Id Multiple Images Uploaded
        /// </summary>
        public List<Guid> ImgId { get; set; }
        public bool AutoOrderIsActive { get; set; }
        public Guid ConfirmedBy { get; set; }
        public DateTime ConfirmedAt { get; set; }
        public string StatusChangeReason { get; set; }
    }

    public partial class ProductOrderStatusUpdateModel : AppBaseModel
    {
        public List<Guid> Items { get; set; }

        /// <summary>
        /// Initiated|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|
        /// </summary>
        public string Status { get; set; }
        public string StatusChangeReason { get; set; }
        public ProductOrderStatusHistoryModel StatusHistory { get; set; }

    }
}
