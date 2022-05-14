using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Notification : BaseEntity
    {
        public NotificationType TypeOfNotification { get; set; }
        public string ReferenceId { get; set; }
        public NotificationPurpose TypeOfPurpose { get; set; }
        public string IconURL { get; set; }
        public string Permalink { get; set; }
        public string Content { get; set; }
    }
}
