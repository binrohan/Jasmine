using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.NotificationArea
{
    public class NotificationModel : DropDownBaseModel
    {
        public NotificationType TypeOfNotification { get; set; }
        public string ReferenceId { get; set; }
        public NotificationPurpose TypeOfPurpose { get; set; }
        public string IconURL { get; set; }
        public string Permalink { get; set; }
        public string Remarks { get; set; }
        public string Content { get; set; }
    }
}
