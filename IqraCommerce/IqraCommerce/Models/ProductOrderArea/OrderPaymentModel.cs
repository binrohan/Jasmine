using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.ProductOrderArea
{
    [Table("OrderPayment")]
    [Alias("pdctctgr")]
    public partial class OrderPaymentModel : AppBaseModel
    {
        public Guid OrderPaymentMethodId { get; set; }
        public Guid ProductOrderId { get; set; }
        public double TotalAmount { get; set; }
        public double PayableAmount { get; set; }
        public double PaidAmount { get; set; }
        /// <summary>
        /// Percentage|Amount
        /// if a product have a regular price 200 and discount 30. 
        /// when DiscountType Percentage is used then discounted price will be 140.
        /// when DiscountType Amount is used then discounted price will be 170.
        /// </summary>
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public double DiscountTotal { get; set; }
        public string PromoCode { get; set; }
        public string Remarks { get; set; }
    }
}
