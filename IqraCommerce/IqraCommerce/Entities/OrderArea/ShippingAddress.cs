using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.OrderArea
{
    [Table("ShippingAddress")]
    [Alias("shippingaddress")]
    public class ShippingAddress : DropDownBaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid RefCustomerId { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public AddressType TypeOfAddress { get; set; }
    }
}
