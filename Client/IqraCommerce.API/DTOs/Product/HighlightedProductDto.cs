using System;
using System.Collections;
using System.Collections.Generic;
using IqraCommerce.API.DTOs.Category;

namespace IqraCommerce.API.DTOs
{
    public class HighlightedProductDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Rank { get; set; }
        public string HighlightedImageURL { get; set; }
    }
}