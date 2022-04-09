using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;

namespace IqraCommerce.API.Data.IServices
{
    public interface IProductService
    {
         Task<IEnumerable<ProductShortDto>> GetLatestProductsAsync(Guid categoryId);
         Task<IEnumerable<ProductShortDto>> GetProductsByBrandAsync(Guid brandId);
         Task<IEnumerable<HighlightedProductDto>> GetHighlightedProductsAsync();
         Task<IEnumerable<ProductShortDto>> GetTopDiscountedProductsAsync();
    }
}