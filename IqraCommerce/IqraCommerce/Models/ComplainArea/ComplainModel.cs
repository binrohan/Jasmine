using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.ComplainArea
{
    [Table("Complain")]
    [Alias("cmpln")]
    public partial class ComplainModel : DropDownBaseModel
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Massege { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>

        public string Status { get; set; } = "Pending";

        public string Remarks { get; set; }
    }

    public partial class ComplainStatusUpdateModel : AppBaseModel
    {
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
