using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class NotificationReturnDto
    {
        public Guid Id { get; set; }
        public NotificationType TypeOfNotification { get; set; }
        public Guid ReferenceId { get; set; }
        public string IconURL { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public bool IsRead { get; set; }
    }
}