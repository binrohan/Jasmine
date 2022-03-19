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
    [Table("Notice")]
    [Alias("ntc")]
    public partial class NoticeModel : DropDownBaseModel
    {
        public string NoticeContent { get; set; }
        public DateTime ActiveAt { get; set; }
        public DateTime EndAt { get; set; }

        /// <summary>
        /// active, deactive
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>
        public Guid ActivityId { get; set; }
        public int Rank { get; set; }

    }
    public partial class NoticeStatusUpdateModel : AppBaseModel
    {
        public List<Guid> Items { get; set; }
        public string Status { get; set; }

    }
}
