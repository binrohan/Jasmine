using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class CustomerNotificationRepository : ICustomerNotificationRepository
    {
        private readonly DataContext _context;
        public CustomerNotificationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerNotification>> GetCustomerNotificationAsync(IList<Guid> ids, Guid customerId)
        {
            return await _context
                            .CustomerNotification
                            .Where(cn => ids.Contains(cn.NotificationId) && cn.CustomerId == customerId)
                            .ToListAsync();
        }
    }
}