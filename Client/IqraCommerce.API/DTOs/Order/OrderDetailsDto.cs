using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.DTOs
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }

       public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public double OrderValue { get; set; }
        public double ShippingCharge { get; set; }
        public double PayableAmount { get; set; }
        public double PaidAmount { get; set; }
        public double PaymentLeft { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Remarks { get; set; }
        public ShippingAddressDto Address { get; set; }
        public IReadOnlyList<OrderProductReturnDto> Products { get; set; }
    }
}