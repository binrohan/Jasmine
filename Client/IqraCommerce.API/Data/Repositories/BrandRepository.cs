using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _context;
        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _context.Brand
                                 .Where(b => !b.IsDeleted && b.IsVisible)
                                 .ToListAsync();
        }
    }
}