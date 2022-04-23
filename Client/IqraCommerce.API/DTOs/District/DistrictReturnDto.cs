using System;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.DTOs
{
    public class DistrictReturnDto
    {
        public DistrictReturnDto()
        {
            
        }
        public DistrictReturnDto(District district)
        {
            Id = district is null ? Guid.Empty : district.Id;
            Name = district?.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}