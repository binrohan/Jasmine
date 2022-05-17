using System;
using System.Collections;
using System.Collections.Generic;
using IqraCommerce.API.DTOs.Category;

namespace IqraCommerce.API.DTOs
{
    public class ProductImageDto 
    {
        public string OriginalImageURL { get; set; }
        public string IconImageURL { get; set; }
        public bool IsPrimary { get; set; }
    }
}