using System;
using System.Collections.Generic;
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
    public class AddressesController : BaseApiController
    {
        private readonly IAddressRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IAddressService _service;
        public AddressesController(
                                  IAddressRepository repo,
                                  IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  IConfiguration config,
                                  IAddressService service
                                  )
        {
            _mapper = mapper;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _config = config;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var customerId = User.RetrieveIdFromPrincipal();

            var addressesFromRepo = await _repo.GetAddressesByCustomerAsync(customerId);

            var addressesToReturn = _mapper.Map<IEnumerable<AddressReturnDto>>(addressesFromRepo);

            return Ok(new ApiResponse(200, addressesToReturn));
        }

        [HttpGet("{addressType}")]
        public async Task<IActionResult> GetAddresses(AddressType addressType)
        {
            var customerId = User.RetrieveIdFromPrincipal();

            var addressFromRepo = await _repo.GetAddressAsync(customerId, addressType);

            if (addressFromRepo is null) return NotFound(new ApiResponse(404, "Address Not Found"));

            var addressToReturn = _mapper.Map<AddressReturnDto>(addressFromRepo);


            return Ok(new ApiResponse(200, addressToReturn));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(AddressUpdateDto addressUpdateDto)
        {
            var customerId = User.RetrieveIdFromPrincipal();

            var addressFromRepo = await _repo.GetAddressesByCustomerAsync(customerId);

            foreach (var address in addressFromRepo)
            {
                if (addressUpdateDto.IsPrimary && address.Id != addressUpdateDto.Id)
                    address.IsPrimary = false;

                if (address.Id == addressUpdateDto.Id)
                    _mapper.Map(addressUpdateDto, address);
            }

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(400);

            var addresFromRepo = await _unitOfWork
                                            .Repository<CustomerAddress>()
                                            .GetByIdAsync(addressUpdateDto.Id);


            var addressToReturn = _mapper.Map<AddressReturnDto>(addressFromRepo);


            return Ok(new ApiResponse(204, addressToReturn));
        }

    }
}