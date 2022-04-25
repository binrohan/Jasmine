using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.PromotionArea
{
    public class CashbackModel : DropDownBaseModel
    {
        public string Code { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public bool IsPublished { get; set; }
        public double MinOrderValue { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
    }
}
