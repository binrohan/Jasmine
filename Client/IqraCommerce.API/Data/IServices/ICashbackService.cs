using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface ICashbackService
    {
        Task<CashbackServiceDto> CalculateAsync(double payAmount);
        Task RedeemAsync(double cashback, Guid customerId);
    }
}