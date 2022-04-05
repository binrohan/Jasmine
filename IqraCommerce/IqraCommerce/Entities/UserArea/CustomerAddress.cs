using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.UserArea
{
    [Table("CustomerAddress")]
    [Alias("customeraddress")]
    public class CustomerAddress : DropDownBaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public AddressType TypeOfAddress { get; set; }
        public bool IsPrimary { get; set; }
    }
}
