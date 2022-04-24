using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class CouponRedeemHistoy : BaseEntity
    {
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }
        public double Value { get; set; }
    }
}
