using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class CashbackHistory : BaseEntity
    {
        public bool IsRedeemed { get; set; }
        public double Amount { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid CashbackId { get; set; }
    }
}
