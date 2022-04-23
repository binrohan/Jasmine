using System;

namespace IqraCommerce.API.DTOs
{
    public class WishlistDto
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}