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
    [Table("Notice")]
    [Alias("ntc")]
    public partial class Notice : DropDownBaseEntity
    {
        public string NoticeContent { get; set; }
        public DateTime ActiveAt { get; set; }
        public DateTime EndAt { get; set; }

        /// <summary>
        /// Active, Deactive
        /// </summary>
        public string Status { get; set; } = "Active";

        /// <summary>
        /// Device Activity
        /// </summary>
        public int Rank { get; set; }

    }
}
