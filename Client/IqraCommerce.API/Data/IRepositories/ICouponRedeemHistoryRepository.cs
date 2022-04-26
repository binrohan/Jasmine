using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface ICouponRedeemHistoryRepository
    {
         Task<CouponRedeemHistory> GetCouponHistoryByCustomer(Guid couponId, Guid customerId);
          Task<CouponRedeemHistory> GetByOrderIdAsync(Guid id);
    }
}