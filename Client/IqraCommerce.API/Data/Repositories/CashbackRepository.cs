using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class CashbackRepository : ICashbackRepository
    {
        private readonly DataContext _context;
        public CashbackRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cashback>> GetCashbacksAsync()
        {
            return await _context
                                .Cashback
                                .Where(c => c.IsPublished
                                            && !c.IsDeleted
                                            && c.StartingAt <= DateTime.Now
                                            && c.EndingAt >= DateTime.Now)
                                .OrderBy(c => c.MinOrderValue)
                                .ToListAsync();
        }
    }
}