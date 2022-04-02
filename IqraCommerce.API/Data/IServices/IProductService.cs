using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;

namespace IqraCommerce.API.Data.IServices
{
    public interface IProductService
    {
         Task<IEnumerable<ProductShortDto>> GetLatestProductsAsync();
         Task<IEnumerable<HighlightedProductDto>> GetHighlightedProductsAsync();
         Task<IEnumerable<ProductShortDto>> GetTopDiscountedProductsAsync();
    }
}