using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class AddressUpdateDto
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpazilaId { get; set; }
        public bool IsPrimary { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}
