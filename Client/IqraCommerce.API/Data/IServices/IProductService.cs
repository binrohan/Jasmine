using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Helpers;

namespace IqraCommerce.API.Data.IServices
{
    public interface IProductService
    {
         Task<Pagination<ProductShortDto>> GetDiscountedProductsAsync(ProductParamDto paramDto);
         Task<IEnumerable<ProductShortDto>> GetRelatedProductsAsync(ProductDetailsDto product);
    }
}