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
    [Table("CategorySlider")]
    [Alias("ctgrsldr")]
    public class CategorySliderModel : AppBaseModel
    {
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Slider Content over Image
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
        public string Remarks { get; set; }
    }
}
