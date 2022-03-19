using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.NoticeArea
{
    [Table("NotificationStatus")]
    [Alias("ntfcstts")]
    public class NotificationStatusModel : AppBaseModel
    {
        public Guid NotificationId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
