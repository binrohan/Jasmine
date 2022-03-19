using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.AppDataArea
{
    [Table("AppCategoryProduct")]
    [Alias("apctgrpdct")]
    public partial class AppCategoryProduct : AppBaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
    }
}
