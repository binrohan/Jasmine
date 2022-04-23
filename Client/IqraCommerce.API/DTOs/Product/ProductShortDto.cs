using System;
using System.Collections;
using System.Collections.Generic;
using IqraCommerce.API.DTOs.Category;

namespace IqraCommerce.API.DTOs
{
    public class ProductShortDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string PackSize { get; set; }
        public string ImageURL { get; set; }
        public double CurrentPrice { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountedPercentage { get; set; }
        public int StockUnit { get; set; }
        public int Rank { get; set; }
    }
}