using System;
using System.Collections.Generic;
using IqraCommerce.API.DTOs;

namespace IqraCommerce.API.DTOs
{
    public class CategoryWithProductDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public IList<ProductShortDto> Products { get; set; }
    }
}