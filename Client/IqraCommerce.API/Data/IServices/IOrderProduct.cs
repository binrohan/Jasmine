using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IOrderProductService
    {
         Task AddAsync(IEnumerable<OrderProductDto> products, Guid orderId);
    }
}