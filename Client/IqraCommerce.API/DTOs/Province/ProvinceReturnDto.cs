using System;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.DTOs
{
    public class ProvinceReturnDto
    {
        public ProvinceReturnDto()
        {
            
        }
        public ProvinceReturnDto(Province province)
        {
            Id = province is null ? Guid.Empty : province.Id;
            Name = province?.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}