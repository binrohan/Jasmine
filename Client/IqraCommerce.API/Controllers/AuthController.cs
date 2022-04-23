using System;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _service;
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOTPService _otpService;
        public AuthController(IAuthService service,
                                  ICustomerRepository repo,
                                  IMapper mapper,
                                  ITokenService tokenService,
                                  IUnitOfWork unitOfWork,
                                  IOTPService otpService)
        {
            _mapper = mapper;
            _repo = repo;
            _service = service;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _otpService = otpService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var customerId = User.RetrieveIdFromPrincipal();

            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(customerId);

            var customerToReturn = _mapper.Map<CustomerAuthDto>(customer);
            customerToReturn.Token = _tokenService.CreateToken(customer);

            return Ok(new ApiResponse(200, customerToReturn));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _otpService.ValidateAsync(registerDto);

            if(!result) return BadRequest(new ApiResponse(406, registerDto, "Wrong OTP"));

            var customer = await _service.RegisterAsync(registerDto);

            if (customer is null) return BadRequest(new ApiResponse(400));

            

            return Ok(new ApiResponse(201, customer, "Registration Successed"));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var customer = await _repo.FindByPhoneAsync(loginDto.Phone);

            if (customer is null) return NotFound(new ApiResponse(404, "Customer Not Found"));

            var result = await _service.CheckPasswordSignInAsync(customer, loginDto.Password);

            if (!result) return Unauthorized(new ApiResponse(401));

            var customerToReturn = _mapper.Map<CustomerAuthDto>(customer);
            customerToReturn.Token = _tokenService.CreateToken(customer);

            return Ok(new ApiResponse(200, customerToReturn, "Login Successed"));
        }

        [HttpGet("PhoneExists")]
        public async Task<IActionResult> CheckEmailExistsAsync([FromQuery] string phone)
        {
            if(string.IsNullOrEmpty(phone))
                return BadRequest(new ApiResponse(400));

            var customer =  await _repo.FindByPhoneAsync(phone);

            if(customer is null) return Ok(new ApiResponse(200, false, "Phone number not in used"));

            return Ok(new ApiResponse(200, true, "Phone already used"));
        }

        
        [HttpPost("RequestOTP")]
        public async Task<IActionResult> RequestOTP(RequestOTPDto requestDto)
        {
            if (await _repo.FindByPhoneAsync(requestDto.Phone) is not null)
            {
                return BadRequest(new ApiResponse(400, requestDto, "Phone already used"));
            }

           var resullt = _otpService.SentSMS(requestDto.Phone);

           var register = new Register
           {
               Id = Guid.NewGuid(),
               IsPassed = false,
               OTP = resullt.Code,
               Password = requestDto.Password,
               Phone = requestDto.Phone
           };

           _unitOfWork.Repository<Register>().Add(register);

           var saveResult =  await _unitOfWork.Complete();

           if(saveResult == 0) return BadRequest(new ApiResponse(400));

           return BadRequest(new ApiResponse(200, register.Id));
        }

    }

}