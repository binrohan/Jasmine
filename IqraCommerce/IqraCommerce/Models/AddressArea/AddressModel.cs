using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.AddressArea
{
    public class AddressModel : DropDownBaseModel
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
        public string Remarks { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
        public Guid ActivityId { get; set; }
    }
}
