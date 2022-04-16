using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Params;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(OrderParam param)
        {
            return await OrderParamExvaluator(param).CountAsync();
        }

        public async Task<IReadOnlyList<Order>> GetOrdersAsync(OrderParam param)
        {
            return await OrderParamExvaluator(param).Skip(param.Skip).Take(param.Take).ToListAsync();
        }

        private IQueryable<Order> OrderParamExvaluator(OrderParam param)
        {
            var query = _context
                            .Order
                            .Where(o => !o.IsDeleted)
                            .Include(o => o.Address)
                            .AsQueryable();

            query = string.IsNullOrEmpty(param.Search)
            ? query
            : query.Where(o => o.OrderNumber.Contains(param.Search));
            query = param.CustomerId == Guid.Empty 
            ? query 
            : query.Where(o => o.CustomerId == param.CustomerId);

            switch (param.OrderBy)
            {
                case OrderBy.CreationDate:
                    query = param.IsDecending ?
                            query.OrderByDescending(p => p.CreatedAt) :
                            query.OrderBy(p => p.CreatedAt);
                    break;

                default:
                    query = param.IsDecending ?
                            query.OrderByDescending(p => p.CreatedAt) :
                            query.OrderBy(p => p.CreatedAt);
                    break;
            }

            return query;
        } 
    }
}