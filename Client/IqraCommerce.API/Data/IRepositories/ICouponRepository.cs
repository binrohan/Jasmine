using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface ICouponRepository
    {
         Task<Coupon> GetCouponByCodeAsync(string code);
        
    }
}