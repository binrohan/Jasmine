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
        public async Task<IEnumerable<Banner>> GetBannersAsync(BannerType bannerType)
        {
            return await _context.Banner.Where(b => !b.IsDeleted && b.IsVisible && b.TypeOfBanner == bannerType)
                                          .OrderBy(c => c.Rank)
                                          .ToListAsync();
        }
    }
}