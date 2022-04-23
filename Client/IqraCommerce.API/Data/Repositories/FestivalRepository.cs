using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class FestivalRepository : IFestivalRepository
    {
        private readonly DataContext _context;
        public FestivalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Festival>> GetFestivalsWithProductsAsync(int take = 10)
        {
            return await _context
                                .Festival
                                .Where(f => !f.IsDeleted
                                            && f.IsVisible
                                            && f.StartDate <= DateTime.Now
                                            && f.EndDate >= DateTime.Now)
                                .Include(f => f.FestivalProducts
                                    .Where(fp => !fp.IsDeleted && !fp.Product.IsDeleted && fp.Product.IsVisible)
                                    .OrderBy(fp => fp.Product.Rank)
                                    .Take(take))
                                .ThenInclude(fp => fp.Product)
                                .OrderBy(c => c.Rank)
                                .ToArrayAsync();

        }
    }
}