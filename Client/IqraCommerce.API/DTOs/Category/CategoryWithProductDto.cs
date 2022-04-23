using System;
using System.Collections.Generic;
using IqraCommerce.API.DTOs;

namespace IqraCommerce.API.DTOs
{
    public class CategoryWithProductDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductShortDto> Products { get; set; }
    }
}