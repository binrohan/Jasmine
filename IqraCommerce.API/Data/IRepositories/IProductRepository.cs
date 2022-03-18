using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}