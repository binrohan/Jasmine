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
    [Table("Notification")]
    [Alias("ntfc")]
    public class Notification : AppBaseEntity
    {
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
    }
}
