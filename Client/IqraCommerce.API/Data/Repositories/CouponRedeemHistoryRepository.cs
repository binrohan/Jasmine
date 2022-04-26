using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class CouponRedeemHistoryRepository : ICouponRedeemHistoryRepository
    {
        private readonly DataContext _context;
        public CouponRedeemHistoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CouponRedeemHistory> GetCouponHistoryByCustomer(Guid couponId, Guid customerId)
        {
            return await _context
                        .CouponRedeemHistory
                        .FirstOrDefaultAsync(crh => crh.CustomerId == customerId
                                                    && crh.CouponId == couponId);
        }

         public async Task<CouponRedeemHistory> GetByOrderIdAsync(Guid id)
        {
            return await _context
                                .CouponRedeemHistory
                                .FirstOrDefaultAsync(c => c.OrderId == id);
        }
    }
}