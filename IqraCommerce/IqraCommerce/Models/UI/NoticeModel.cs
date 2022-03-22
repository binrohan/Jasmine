using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.UI
{
    public partial class NoticeModel : DropDownBaseModel
    {
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsVisible { get; set; }
        public int Rank { get; set; }
        public string Remarks { get; set; }
    }
}
