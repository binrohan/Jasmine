using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.NotificationArea
{
    public class CustomerNotificationModel : DropDownBaseModel
    {
        public Guid CustomerId { get; set; }
        public Guid NotificationId { get; set; }
        public bool IsRead { get; set; }
        public string Remarks { get; set; }
    }
}
