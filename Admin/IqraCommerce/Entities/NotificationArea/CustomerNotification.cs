using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.NotificationArea
{
    [Table("CustomerNotification")]
    [Alias("customernotification")]
    public class CustomerNotification : DropDownBaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid NotificationId { get; set; }
        public bool IsRead { get; set; }
    }
}
