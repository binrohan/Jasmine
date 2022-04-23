using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class Wishlist : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}