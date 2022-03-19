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
    [Table("Notification")]
    [Alias("ntfc")]
    public class NotificationModel : AppBaseModel
    {
        public NotificationModel() {

        }
        public NotificationModel(Guid customerId, Guid referenceId, string reference, string content)
        {
            CustomerId = customerId;
            ReferenceId = referenceId;
            Reference = reference;
            Content = content;
            Type = "Customer";

        }
        /// <summary>
        /// When All then CustomerId is empty.
        /// </summary>
        public Guid CustomerId { get; set; }
        public Guid ReferenceId { get; set; }
        public string Reference { get; set; }
        /// <summary>
        /// All|Customer
        /// </summary>
        public string Type { get; set; }
        public string Content { get; set; }
        public string Remarks { get; set; }
    }
}
