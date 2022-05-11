using System;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Constants;
using IqraCommerce.API.Data;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IqraCommerce.API.Controllers
{
    [Authorize]
    public class CustomersController : BaseApiController
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly ICustomerService _service;
        public CustomersController(
                                  ICustomerRepository repo,
                                  IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  IConfiguration config,
                                  ICustomerService service
                                  )
        {
            _mapper = mapper;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _config = config;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var customerId = User.RetrieveIdFromPrincipal();

            var customer = await _repo.GetCustomerAsync(customerId);

            var customerToReturn = _mapper.Map<CustomerReturnDto>(customer);

            return Ok(new ApiResponse(200, customerToReturn));
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer([FromForm]CustomerUpdateDto customerUpdate)
        {
            var customerId = User.RetrieveIdFromPrincipal();

            var customerFromRepo = await _unitOfWork.Repository<Customer>().GetByIdAsync(customerId);

            customerFromRepo.Name = customerUpdate.Name;
            customerFromRepo.Email = customerUpdate.Email;

            if(customerUpdate.ProfilePicture is not  null)
            {
                ImageManager imageManager = new ImageManager(_config);

                customerFromRepo.ImageURL = imageManager.Store(customerUpdate.ProfilePicture, Subdirs.customer);              
            }

            var result = await _unitOfWork.Complete();

            if(result == 0) return BadRequest(400);

            var customerToReturn = _mapper.Map<CustomerReturnDto>(customerFromRepo);

            return Ok(new ApiResponse(200, customerToReturn));
        }

        [HttpGet("Addresses")]
        public async Task<IActionResult> GetAddresses()
        {
             var customerId = User.RetrieveIdFromPrincipal();

             var addresses = await _service.GetAddressesAsync(customerId);

             return Ok(new ApiResponse(200, addresses));
        }

        [HttpGet("Address/{addressType}")]
        public async Task<IActionResult> GetAddresses(AddressType addressType)
        {
             var customerId = User.RetrieveIdFromPrincipal();

             var address = await _service.GetAddressesAsync(customerId, addressType);

             if(address is null) return NotFound(new ApiResponse(404, "Address Not Found"));

             return Ok(new ApiResponse(200, address));
        }
    }
}