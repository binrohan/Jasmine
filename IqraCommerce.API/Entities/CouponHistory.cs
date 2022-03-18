using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class CouponHistory
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public double CoupenAmount { get; set; }
        public double OrderAmount { get; set; }
        public double OrderDiscount { get; set; }
        public string Status { get; set; }
    }
}
