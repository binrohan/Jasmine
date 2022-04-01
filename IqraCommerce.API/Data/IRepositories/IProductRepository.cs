using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Product>> GetProductsByCategoriesAsync(int take, IList<Guid> listOfCategoriesId);
        Task<IEnumerable<Product>> GetLatestProducts(int take);
    }
}