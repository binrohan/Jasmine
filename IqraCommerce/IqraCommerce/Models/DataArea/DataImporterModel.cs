using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.DataArea
{
    [Table("DataImporter")]
    [Alias("dtmprtr")]
    public class DataImporterModel : AppBaseModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string DosageForm { get; set; }
        public string Strength { get; set; }
        public string GenericName { get; set; }
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
