using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Params;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IOrderRepository
    {
         Task<int> CountAsync(OrderParam param);
         Task<IReadOnlyList<Order>> GetOrdersAsync(OrderParam param);
    }
}