using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.PromotionArea
{
    [Table("CouponRedeemHistory")]
    [Alias("Couponredeemhistory")]
    public class CouponRedeemHistory : DropDownBaseEntity
    {
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }
        public double Value { get; set; }
    }
}
