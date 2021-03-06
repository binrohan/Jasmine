using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface ICashbackHistoryService
    {
        Task AddHistoryAsync(OrderPaymentDto payment, Guid customerId, Guid orderId);
    }
}