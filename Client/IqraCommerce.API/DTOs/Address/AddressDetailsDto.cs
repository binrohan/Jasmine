using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class AddressDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ProvinceReturnDto Province { get; set; }
        public DistrictReturnDto District { get; set; }
        public UpazilaReturnDto Upazila { get; set; }
        public AddressType TypeOfAddress { get; set; }
        public bool IsPrimary { get; set; }
        public string Remarks { get; set; }
    }
}
