using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("SafetyItem")]
    [Alias("sftitm")]
    public class SafetyItem : DropDownBaseEntity
    {
        /// <summary>
        /// Icom Path
        /// </summary>
        public string Icon { get; set; }
    }
}
