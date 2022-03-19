using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.CommonArea
{
    [Table("Perks")]
    [Alias("prks")]
    public class Perks:AppBaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string IconPath { get; set; }
        /// <summary>
        /// Top|Bottom
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
    }
}
