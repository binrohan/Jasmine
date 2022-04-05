using System;
using System.Threading.Tasks;
using IqraCommerce.API.Controllers;
using IqraCommerce.API.Data;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Auth;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly SignInManager<Customer> _signInManager;
        private readonly UserManager<Customer> _userManager;
        public AuthController(DataContext context,
                              SignInManager<Customer> signInManager,
                              UserManager<Customer> userManager)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            // if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            // {
            //     return new BadRequestObjectResult(new ApiValidationErrorResponse{Errors = new[] {"Email address is in use"}});
            // }

            var customer = new Customer
            {
                Phone = registerDto.Phone,
                Password = registerDto.Password
            };

            // var user = new AppUser
            // {
            //     DisplayName = registerDto.DisplayName,
            //     Email = registerDto.Email,
            //     UserName = registerDto.Email
            // };

            var result = await _userManager.CreateAsync(customer, registerDto.Password);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return Ok(new ApiResponse(201, customer, "Registration Successed"));
        }
    }
}