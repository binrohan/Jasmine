using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.PromotionArea
{
    [Table("CashbackHistory")]
    [Alias("cashbackhistory")]
    public class CashbackHistory : DropDownBaseEntity
    {
        public bool IsRedeemed { get; set; }
        public double Amount { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid CashbackId { get; set; }
    }
}
