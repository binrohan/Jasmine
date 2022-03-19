using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ContactArea
{
    [Table("Address")]
    [Alias("adrs")]
    public class Address : DropDownBaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public int UnionId { get; set; }
        /// <summary>
        /// Home|Office|Home Town
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// One customer can have only one Default Address.
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Remarks is Address
        /// </summary>
        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
