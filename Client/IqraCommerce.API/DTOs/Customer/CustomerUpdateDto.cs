using System;
using Microsoft.AspNetCore.Http;

namespace IqraCommerce.API.DTOs
{
    public class CustomerUpdateDto
    {
        public IFormFile ProfilePicture { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}