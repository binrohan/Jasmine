using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByProductAsync(Guid productId);
        Task<IEnumerable<Category>> GetHomeCategoriesAsync();
        Task<IEnumerable<Category>> GetChildCategoriesWithProductsAsync(Guid category);

    }
}