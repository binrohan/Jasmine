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

        public async Task<int> CountAsync(NotificationParam param)
        {
            return await NotificaionParamExvaluator(param).CountAsync();
        }

        public async Task<IReadOnlyList<Notification>> GetNotificationsAsync(NotificationParam param)
        {
            return await NotificaionParamExvaluator(param).Skip(param.Skip).Take(param.Take).ToListAsync();
        }

        private IQueryable<Notification> NotificaionParamExvaluator(NotificationParam param)
        {
            var query = _context
                            .Notification
                            .Include(n => n.CustomerNotifications
                                .Where(cn => cn.CustomerId == param.CustomerId))
                            .AsQueryable();

            return query;
        } 
    }
}