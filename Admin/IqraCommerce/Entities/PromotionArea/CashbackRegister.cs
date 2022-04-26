using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.PromotionArea
{
    [Table("CashbackRegister")]
    [Alias("cashbackregister")]
    public class CashbackRegister : DropDownBaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid RefCashbackId { get; set; }
        public Guid CustomerId { get; set; }
        public double Amount { get; set; }
        public CashbackRegisterStatus Status { get; set; }
    }
}
