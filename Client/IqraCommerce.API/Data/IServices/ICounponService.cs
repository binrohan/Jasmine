using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface ICouponService
    {
        Task<CouponServiceDto> DiscountAsync(double orderValue, string code, Guid customerId);
        Task RedeemAsync(Guid id);
    }
}