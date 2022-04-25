using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.PromotionArea
{
    public class CashbackHistoryModel : DropDownBaseModel
    {
        public bool IsRedeemed { get; set; }
        public double Amount { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public string Remarks { get; set; }
    }
}
