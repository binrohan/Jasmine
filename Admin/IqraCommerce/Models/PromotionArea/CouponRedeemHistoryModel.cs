using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.PromotionArea
{
    public class CouponRedeemHistoryModel : DropDownBaseModel
    {
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }
        public double Value { get; set; }
        public Guid OrderId { get; set; }
        public string Remarks { get; set; }
    }
}
