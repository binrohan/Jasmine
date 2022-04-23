using System.Collections.Generic;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.DTOs
{
    public class BrandsReturnDto
    {
        public IDictionary<char, IList<BrandReturnDto>> Brands { get; set; }

        public BrandsReturnDto(IDictionary<char,IList<BrandReturnDto>> brands)
        {
            Brands = brands;
        }
    }
}