using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.NoticeArea
{

    [Table("NotificationStatus")]
    [Alias("ntfcstts")]
    public class NotificationStatus : AppBaseEntity
    {
        public Guid NotificationId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
