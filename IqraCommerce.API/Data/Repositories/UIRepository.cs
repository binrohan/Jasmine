using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{
    public class UIRepository : IUIRepository
    {
        private readonly DataContext _context;
        public UIRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Banner>> GetBannersAsync()
        {
            return await _context.Banner.Where(b => !b.IsDeleted && b.IsVisible)
                                          .OrderBy(c => c.Rank)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Notice>> GetNoticesAsync()
        {
            return await _context.Notice.Where(b => !b.IsDeleted && b.IsVisible)
                                          .OrderBy(c => c.Rank)
                                          .ThenBy(b => b.Content)
                                          .ToListAsync();
        }
    }
}