using System;
using System.ComponentModel.DataAnnotations;

namespace IqraCommerce.API.DTOs
{
    public class BaseCreateDto
    {
        [Required]
        public Guid ActivityId { get; set; }
    }
}