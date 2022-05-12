using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;

namespace IqraCommerce.API.Data.IServices
{
    public interface IProductService
    {
         Task<IEnumerable<ProductShortDto>> GetTopDiscountedProductsAsync();
    }
}