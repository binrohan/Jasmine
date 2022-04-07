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
         Task<CustomerReturnDto> RegisterAsync(RegisterDto register);

         Task<bool> CheckPasswordSignInAsync(Customer customer, string password);
    }
}