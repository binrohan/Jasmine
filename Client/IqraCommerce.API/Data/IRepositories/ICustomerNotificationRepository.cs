using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface ICustomerNotificationRepository
    {
        Task<IEnumerable<CustomerNotification>> GetCustomerNotificationAsync(IList<Guid> ids, Guid customerId);
    }
}