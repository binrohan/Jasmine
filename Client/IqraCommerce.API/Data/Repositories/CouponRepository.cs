using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class CouponRepository : ICouponRepository
    {
        private readonly DataContext _context;
        public CouponRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Coupon> GetCouponByCodeAsync(string code)
        {
            return await _context
                        .Coupon
                        .FirstOrDefaultAsync(c => c.IsPublished
                                                  && !c.IsDeleted
                                                  && c.StartingAt <= DateTime.Now
                                                  && c.EndingAt >= DateTime.Now
                                                  && c.Code == code);
        }
    }
}