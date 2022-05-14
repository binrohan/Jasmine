using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface INotificationService
    {
        Task<int> MarkNotificationAsSeenAsync(IList<Guid> ids, Guid customerId);
    }
}