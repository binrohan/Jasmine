using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class CashbackRegister : BaseEntity
    {

         public Guid OrderId { get; set; }
        public Guid RefCashbackId { get; set; }
        public Guid CustomerId { get; set; }
        public double Amount { get; set; }
        public CashbackRegisterStatus Status { get; set; }
    }
}
