using System;

namespace IqraCommerce.API.DTOs
{
    public class OrderProductReturnDto
    {
        public Guid Id { get; set; }
        public Guid RefProductId { get; set; }
        public string DisplayName { get; set; }
        public double CurrentPrice { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
    }
}