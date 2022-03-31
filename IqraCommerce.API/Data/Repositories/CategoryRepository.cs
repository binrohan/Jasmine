using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
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
                                          .ThenBy(c => c.Name)
                                          .Include(c => c.ProductCategories)
                                          .ThenInclude(p => p.Product)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByProductAsync(Guid productId)
        {
            return await _context.Category
                .Join(_context.ProductCategory
                .Where(pc => pc.IsDeleted == false
                        && pc.ProductId == productId), 
                        c => c.Id, 
                        pc => pc.CategoryId, 
                        (c, pc) => c)
                .Where(c => !c.IsDeleted && c.IsVisible)
                .ToListAsync();


        }

        public async Task<IEnumerable<Category>> GetChildCategoriesWithProductsAsync(Guid categoryId)
        {
            return await _context.Category
                    .Where(c => c.ParentId == categoryId && !c.IsDeleted && c.IsVisible)
                    .Include(c => c.ProductCategories
                        .Where(pc => !pc.IsDeleted && !pc.Product.IsDeleted && pc.Product.IsVisible)
                        .OrderBy(pc => pc.Product.Rank)
                        .Take(10))
                        .ThenInclude(pc => pc.Product)
                    .OrderBy(c => c.Rank)
                    .ToArrayAsync();
        }

        public async Task<IEnumerable<Category>> GetChildCategoriesAsync(Guid categoryId)
        {
            return await _context.Category
                    .Where(c => c.ParentId == categoryId && !c.IsDeleted && c.IsVisible)
                    .OrderBy(c => c.Rank)
                    .ToArrayAsync();
        }
    }
}