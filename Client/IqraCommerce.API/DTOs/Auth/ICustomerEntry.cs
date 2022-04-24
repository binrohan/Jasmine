using System;

namespace IqraCommerce.API.DTOs
{
    public interface IAuthCustomer
    {
        string Phone { get; set; }
        string Password { get; set; }
        Guid RequestId { get; set; }
        string OTP { get; set; }
    }
}