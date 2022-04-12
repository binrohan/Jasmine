using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.AddressArea
{
    [Table("Thana")]
    [Alias("thn")]
    public partial class Thana : DropDownBaseEntity
    {
        public Guid DistictId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
