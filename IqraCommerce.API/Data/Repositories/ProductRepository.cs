using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;
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
        
        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await _context.Product.Include(p => p.Unit)
                                         .Include(p => p.Brand)
                                         .FirstOrDefaultAsync(p => !p.IsDeleted
                                                                    && p.IsVisible
                                                                    && p.Id == productId);

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Product
                                 .Where(p => !p.IsDeleted && p.IsVisible)
                                 .ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetHighlightedProductsAsync()
        {
            return await _context.Product
                                 .Where(p => !p.IsDeleted && p.IsVisible && p.IsHighlighted)
                                 .ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId)
        {
           return await _context.ProductCategory
                                .Where(pc => !pc.IsDeleted && pc.CategoryId == categoryId)
                                .Join(_context.Product
                                              .Where(p => !p.IsDeleted && p.IsVisible),
                                     pc => pc.ProductId,
                                     p => p.Id,
                                     (pc, p) => p)
                                .ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoriesAsync(int take, IList<Guid> listOfCategoriesId)
        {
            return await _context.ProductCategory
                                .Where(pc => !pc.IsDeleted && listOfCategoriesId.Contains(pc.CategoryId))
                                .Join(_context.Product
                                              .Where(p => !p.IsDeleted && p.IsVisible),
                                     pc => pc.ProductId,
                                     p => p.Id,
                                     (pc, p) => p)
                                .Take(take)
                                .ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetLatestProducts(int take)
        {
            return await _context.Product
                                 .Where(p => !p.IsDeleted && p.IsVisible)
                                 .OrderBy(p => p.CreatedAt)
                                 .Take(take)
                                 .ToArrayAsync();
        }
    }
}