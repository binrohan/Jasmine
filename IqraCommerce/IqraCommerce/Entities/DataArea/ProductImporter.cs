using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.DataArea
{
    [Table("ProductImporter")]
    [Alias("pdctmprtr")]
    public class ProductImporter : AppBaseEntity
    {
        public ProductImporter()
        {

        }
        public ProductImporter(Guid UserId)
        {
            CreatedBy = UpdatedBy = UserId;
        }
        public string Name { get; set; }
        public string Strength { get; set; }
        public string GenericName { get; set; }
        public string Company { get; set; }
        public double MRP { get; set; }
        public double PackSize { get; set; }
        public double PackPrice { get; set; }
        /// <summary>
        /// which number of page.
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Json Object Created
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Json Object Orginal
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Orginal Response From this url.
        /// </summary>
        public string HTML { get; set; }
        public string Url { get; set; }
    }
}
