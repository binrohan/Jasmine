using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Address : BaseEntity
    {
       
        public Guid CustomerId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public int UnionId { get; set; }
        public string Type { get; set; }
        public bool IsDefault { get; set; }
    }
}
