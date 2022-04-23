using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class OrderHistory : BaseEntity
    {
        public Guid OrderId { get; set; }
        public OrderAction TypeOfAction { get; set; }
    }
}
