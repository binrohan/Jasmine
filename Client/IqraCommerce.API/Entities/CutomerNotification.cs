using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class CustomerNotification : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid NotificationId { get; set; }
        public bool IsRead { get; set; }
    }
}
