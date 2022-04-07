using System;

namespace IqraCommerce.API.DTOs
{
    public class RegisterDto
    {
        public string Phone { get; set; }
        public string Password { get; set; }
        public Guid RequestId { get; set; } = Guid.Empty;
        public string OTP { get; set; }
    }
}