using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class PromotionRepository : IPromotionRepository
    {
        private readonly DataContext _context;
        public PromotionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Promotion>> GetPromotionsAsync()
        {
            return await _context
                        .Promotion
                        .Where(o => !o.IsDeleted
                                    && o.IsVisible
                                    && o.StartingAt <= DateTime.Now
                                    && o.EndingAt >= DateTime.Now)
                        .OrderBy(o => o.Rank)
                        .ToListAsync();
        }
    }
}