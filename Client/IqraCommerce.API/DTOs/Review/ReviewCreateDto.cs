using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class ReviewCreateDto
    {
        public string Content { get; set; }
        public Guid ProductId { get; set; }
    }
}
