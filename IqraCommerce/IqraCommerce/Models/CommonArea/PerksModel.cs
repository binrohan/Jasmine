using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.CommonArea
{
    [Table("Perks")]
    [Alias("prks")]
    public class PerksModel : AppBaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// Top|Bottom
        /// </summary>
        public string Type { get; set; }
        public string Remarks { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
        public Guid ActivityId { get; set; }
    }
}
