using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;
using static IqraCommerce.API.Data.IRepositories.IGenericRepository;

namespace IqraCommerce.API.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _context.Brand.Where(b => !b.IsDeleted && b.IsVisible).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Category.Where(b => !b.IsDeleted && b.IsVisible)
                                          .OrderBy(c => c.Level)
                                          .ThenBy(c => c.Name)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetHomeCategoriesAsync()
        {
            return await _context.Category.Where(b => !b.IsDeleted && b.IsVisible && b.IsVisibleInHome)
                                          .OrderBy(c => c.Rank)
                                          .ThenBy(c => c.Name).Include(c => c.ProductCategories).ThenInclude(p => p.Product)
                                          .ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await _context.Product.Include(p => p.Unit)
                                         .Include(p => p.Brand)
                                         .FirstOrDefaultAsync(p => !p.IsDeleted
                                                                    && p.IsVisible
                                                                    && p.Id == productId);
                                                                    
        }

        public async Task<Product> GetProductAsyncEx(Guid productId)
        {
            return await _context.Product.Include(p => p.Unit)
                                         .Include(p => p.Brand)
                                         .Include(p => p.ProductCategories
                                            .Join(_context.Category,
                                                    pc => pc.CategoryId,
                                                    c => c.Id,
                                                    (pc, c) => c))
                                         .Where(p => p.IsDeleted == false
                                                     && p.IsVisible == true
                                                     && p.Id == productId)
                                         .FirstAsync();
        }
    }
}