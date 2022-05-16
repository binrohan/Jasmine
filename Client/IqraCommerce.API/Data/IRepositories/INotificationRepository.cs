using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Params;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface INotificationRepository
    {
        Task<int> GetUnseenNotificationCountAsync(Guid userId);
        Task<int> CountAsync(NotificationParam param);
        Task<IReadOnlyList<Notification>> GetNotificationsAsync(NotificationParam param);
    }
}