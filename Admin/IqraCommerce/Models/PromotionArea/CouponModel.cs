using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.PromotionArea
{
    public class CouponModel : DropDownBaseModel
    {
        public string Code { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public bool IsPublished { get; set; }
        public bool IsLimited { get; set; }
        public int Redeemed { get; set; }
        public int Count { get; set; }
        public double MinOrderValue { get; set; }
        public double MaxDiscount { get; set; }
        public double MinDiscount { get; set; }
        public double Discount { get; set; }
        public string Remarks { get; set; }
    }
}
