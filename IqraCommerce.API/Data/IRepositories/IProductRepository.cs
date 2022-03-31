using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId);
    }
}