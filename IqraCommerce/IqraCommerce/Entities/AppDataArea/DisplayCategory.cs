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
    
    [Table("DisplayCategory")]
    [Alias("dsplctgr")]
    public partial class DisplayCategory : AppBaseEntity
    {
        public Guid CategoryId { get; set; }
        /// <summary>
        /// TopCategory|DisplayCategory|SpecialProducts
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
    }
}
