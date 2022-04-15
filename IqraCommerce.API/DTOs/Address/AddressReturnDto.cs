using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class AddressReturnDto
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid ProvinceId { get; set; }
        public ProvinceReturnDto Province { get; set; }
        public Guid DistrictId { get; set; }
        public DistrictReturnDto District { get; set; }
        public Guid UpazilaId { get; set; }
        public UpazilaReturnDto Upazila { get; set; }
        public AddressType TypeOfAddress { get; set; }
        public bool IsPrimary { get; set; }
    }
}
