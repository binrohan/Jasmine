using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IqraCommerce.API.Data.Services
{
    public class OTPService : IOTPService
    {
        private readonly IConfiguration _config;
        private readonly IConfiguration _OTP;
        private readonly IUnitOfWork _unitOfWork;
        public OTPService(IConfiguration config, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _OTP = _config.GetSection("OTP");
        }

        public OTPSentResult SentSMS(string phone)
        {
            OTPSentResult result = new OTPSentResult();
            result.Code = GenerateOTP();

            using (WebClient wc = new WebClient())
            {
                try
                {
                    var serviceURL = SMSURL(phone, result.Code);
                    result.Response = wc.UploadString(serviceURL, "");
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

            return result;
        }

        public async Task<bool> ValidateAsync(RegisterDto register)
        {
           var registerFromRepo = await _unitOfWork.Repository<Register>().GetByIdAsync(register.RequestId);

           return registerFromRepo.OTP == register.OTP
                && registerFromRepo.Phone == register.Phone
                && register.Password == registerFromRepo.Password;
        } // 23f00c9e-a007-4f69-93eb-cf6426a980f5

        private string SMSURL(string phone, string code)
        {
            var url = _OTP["SMS_SERVICE_URL"];
            var content = _OTP["SMS_CONTENT"];

            content = content.Replace("{{OTP}}", code);

            url = url.Replace("{{phone}}", phone);
            url = url.Replace("{{content}}", content);

            return url;
        }

        private string GenerateOTP()
        {
            return new Random().Next(1000, 9999).ToString();
        }


    }
}