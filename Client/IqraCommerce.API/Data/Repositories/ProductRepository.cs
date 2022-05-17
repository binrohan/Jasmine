using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;
using IqraCommerce.API.Params;
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
                                         .Include(p => p.Images.Where(i => !i.IsDeleted))
                                         .FirstOrDefaultAsync(p => !p.IsDeleted
                                                                    && p.IsVisible
                                                                    && p.Id == productId);

        }

        public async Task<IEnumerable<Product>> GetProductsAsync(ProductParam param)
        {
            var query = _context.Product
                                 .Include(p => p.Images.Where(i => !i.IsDeleted))
                                 .Where(p => p.IsDeleted == param.IsDeleted
                                             && p.IsVisible == param.IsVisible)
                                 .AsQueryable();
            
            query = param.IsHighlighted is null ? query : query.Where(p => p.IsHighlighted == param.IsHighlighted);

            switch (param.OrderBy)
            {
                case OrderBy.Rank:
                    query = param.IsDecending ? 
                            query.OrderByDescending(p => p.Rank) : 
                            query.OrderBy(p => p.Rank);
                    break;

                case OrderBy.Name:
                    query = param.IsDecending ? 
                            query.OrderByDescending(p => p.Name) : 
                            query.OrderBy(p => p.Name);
                    break;

                case OrderBy.Discount:
                    query = param.IsDecending ? 
                            query.OrderByDescending(p => p.DiscountedPercentage) : 
                            query.OrderBy(p => p.DiscountedPercentage);
                    break;

                case OrderBy.CreationDate:
                    query = param.IsDecending ? 
                            query.OrderByDescending(p => p.CreatedAt) : 
                            query.OrderBy(p => p.CreatedAt);
                    break;

                default:
                    query = param.IsDecending ? 
                                query.OrderByDescending(p => p.Rank) : 
                                query.OrderBy(p => p.Rank);
                        break;
            }

            var products = await query.Take(param.Take).ToListAsync();

            return products;
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

        public async Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<Guid> ListOfProductId)
        {
            return await _context.Product
                                 .Where(p => !p.IsDeleted
                                             && p.IsVisible
                                             && ListOfProductId.Contains(p.Id))
                                 .OrderBy(p => p.CreatedAt)
                                 .ToArrayAsync();
        }
    }
}