using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DataContext _context;
        public NotificationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> GetUnseenNotificationCountAsync(Guid customerId)
        {
            return await _context
                        .CustomerNotification
                        .Where(cn => cn.CustomerId == customerId && !cn.IsRead)
                        .CountAsync();
        }
    }
}