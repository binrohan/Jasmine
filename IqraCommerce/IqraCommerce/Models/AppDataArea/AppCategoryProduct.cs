using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.AppDataArea
{
    [Table("AppCategoryProduct")]
    [Alias("apctgrpdct")]
    public partial class AppCategoryProductModel : AppBaseModel
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
        public string Remarks { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
