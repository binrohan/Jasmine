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
        public Guid RefAddressId { get; set; }


        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpazilaId { get; set; }
        public AddressType TypeOfAddress { get; set; }
    }
}
