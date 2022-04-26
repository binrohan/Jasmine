using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OrderReturnDto
    {
       public string OrderNumber { get; set; }
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
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Remarks { get; set; }
        public double CashbackRegistered { get; set; }
    }
}