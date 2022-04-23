using System;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.DTOs
{
    public class UpazilaReturnDto
    {
        public UpazilaReturnDto()
        {
            
        }
        public UpazilaReturnDto(Upazila upazila)
        {
            Id = upazila is null ? Guid.Empty : upazila.Id;
            Name = upazila?.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}