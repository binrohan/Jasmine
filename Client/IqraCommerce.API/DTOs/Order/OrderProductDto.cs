using System;

namespace IqraCommerce.API.DTOs
{
    public class OrderProductDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}