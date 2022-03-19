using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.AddressArea
{
    [Table("ThanaModel")]
    [Alias("thn")]
    public partial class ThanaModel : DropDownBaseModel
    {
        public Guid ProvienceId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Remarks { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
