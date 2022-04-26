using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface ICashbackRegisterService
    {
        void Register(CashbackServiceDto cashback, Guid customerId, Guid orderId);
        Task<CashbackRegister> GetByOrderIdAsync(Guid id); 
    }
}