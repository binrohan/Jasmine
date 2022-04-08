using System;

namespace IqraCommerce.API.DTOs
{
    public class CustomerAuthDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}