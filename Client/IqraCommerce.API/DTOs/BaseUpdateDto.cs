using System;
using System.ComponentModel.DataAnnotations;

namespace IqraCommerce.API.DTOs
{
    public class BaseUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public Guid ActivityId { get; set; }
    }
}