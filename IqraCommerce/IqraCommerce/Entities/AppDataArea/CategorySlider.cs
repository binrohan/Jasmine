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
    [Table("CategorySlider")]
    [Alias("ctgrsldr")]
    public class CategorySlider : AppBaseEntity
    {
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Slider Content over Image
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Image Path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
    }
}
