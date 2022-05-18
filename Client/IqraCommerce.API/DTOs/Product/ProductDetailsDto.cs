using System;
using System.Collections;
using System.Collections.Generic;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.DTOs
{
    public class ProductDetailsDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Excerpt { get; set; } 
        public string PackSize { get; set; }


        public double CurrentPrice { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountedPercentage { get; set; }

        public int StockUnit { get; set; }


        public int Rank { get; set; }

        public double Rating { get; set; }
        public int RatingCount { get; set; }

        public string Description { get; set; }

        public UnitReturnDto Unit { get; set; }
        public IEnumerable<CategoryShortDto> Categories { get; set; }
        public IEnumerable<ProductImageDto> Images  { get; set; }
        public IEnumerable<ProductShortDto> RelatedProducts { get; set; }
    }
}