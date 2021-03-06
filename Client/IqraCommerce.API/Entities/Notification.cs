using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Notification : BaseEntity
    {
        public NotificationType TypeOfNotification { get; set; }
        public Guid ReferenceId { get; set; }
        public string IconURL { get; set; }
        public string Content { get; set; }
        public ICollection<CustomerNotification> CustomerNotifications { get; set; }
    }
}
