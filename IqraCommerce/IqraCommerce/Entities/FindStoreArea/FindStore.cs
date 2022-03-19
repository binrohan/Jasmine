using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.FindStoreArea
{
    [Table("FindStore")]
    [Alias("fndstr")]
    public partial class FindStore : DropDownBaseEntity
    {
        /// <summary>
        /// Address field
        /// </summary>
        public string Location { get; set; }
        public int Mobile { get; set; }
        public string BranchEmail { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string ShortInformation { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
