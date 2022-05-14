using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.NotificationArea
{
    [Table("Notification")]
    [Alias("notification")]
    public class Notification : DropDownBaseEntity
    {
        public NotificationType TypeOfNotification { get; set; }
        public Guid ReferenceId { get; set; }
        public string IconURL { get; set; }
        public string Content { get; set; }
    }
}
