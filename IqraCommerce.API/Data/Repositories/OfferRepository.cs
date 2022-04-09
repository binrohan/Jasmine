using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class OfferRepository : IOfferRepository
    {
        private readonly DataContext _context;
        public OfferRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await _context
                        .Offer
                        .Where(o => !o.IsDeleted
                                    && o.IsVisible
                                    && o.StartingAt <= DateTime.Now
                                    && o.EndingAt >= DateTime.Now)
                        .OrderBy(o => o.Rank)
                        .ToListAsync();
        }
    }
}