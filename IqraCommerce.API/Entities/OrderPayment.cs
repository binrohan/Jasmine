using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class OrderPayment
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid ProductOrderId { get; set; }
        public double TotalAmount { get; set; }
        public double PayableAmount { get; set; }
        public double PaidAmount { get; set; }
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public double DiscountTotal { get; set; }
        public string PromoCode { get; set; }
        public string Status { get; set; }
    }
}
