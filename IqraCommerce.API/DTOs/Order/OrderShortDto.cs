using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OrderShortDto
    {
        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public double PayableAmount { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ShippingAddressDto Address { get; set; }
    }
}