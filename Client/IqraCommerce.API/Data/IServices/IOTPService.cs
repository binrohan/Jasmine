using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;

namespace IqraCommerce.API.Data.IServices
{
    public interface IOTPService
    {
        OTPSentResult SentSMS(string phone);
        Task<bool> ValidateAsync(IAuthCustomer authCustomer);
    }
}