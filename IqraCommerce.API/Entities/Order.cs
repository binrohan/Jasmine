using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public double OrderValue { get; set; }
        public double ShippingCharge { get; set; }
        public double PayableAmount { get; set; }
        public double PaidAmount { get; set; }
        public double PaymentLeft { get; set; }
        public int TotalProducts { get; set; }
        public int TotalQuantity { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PlatformType TypeOfPlatForm { get; set; }
    }
}
