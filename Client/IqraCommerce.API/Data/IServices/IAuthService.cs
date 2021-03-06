using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;

namespace IqraCommerce.API.Data.IServices
{
    public interface IAuthService
    {
         Task<CustomerAuthDto> RegisterAsync(RegisterDto register);
         Task<int> ResetPasswordAsync(string phone, string password);
         Task<bool> CheckPasswordSignInAsync(Customer customer, string password);
    }
}