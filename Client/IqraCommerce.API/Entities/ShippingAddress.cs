using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class ShippingAddress : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid RefCustomerId { get; set; }
        public Guid RefAddressId { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid ProvinceId { get; set; }
        public Province Province { get; set; }
        public Guid DistrictId { get; set; }
        public District District { get; set; }
        public Guid UpazilaId { get; set; }
        public Upazila Upazila { get; set; }
        public AddressType TypeOfAddress { get; set; }
    }
}
