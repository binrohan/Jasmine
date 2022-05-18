using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Review : BaseEntity
    {
        public string Content { get; set; }
        public Guid ProductId { get; set; }
        public ReviewState StateOfReview { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

