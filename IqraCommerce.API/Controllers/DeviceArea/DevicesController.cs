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
    public class DeviceAreaController : BaseApiController
    {
        private readonly IDeviceRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeviceAreaController(
                                  IDeviceRepository repo,
                                  IMapper mapper,
                                  IUnitOfWork unitOfWork
                                  )
        {
            _mapper = mapper;
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> GetDeviceId(DeviceSetDto deviceSetDto)
        {
            var userId = User?.RetrieveIdFromPrincipal() ?? Guid.Empty;

            var deviceFromRepo = await _repo.GetDeviceByUserAgentAsync(deviceSetDto.UserAgent);

            if(deviceFromRepo is not null) return BadRequest(new ApiResponse(400));

            var deviceToSet = _mapper.Map<Device>(deviceSetDto);
            deviceToSet.UserId = userId;

            _unitOfWork.Repository<Device>().Add(deviceToSet);

            var result = await _unitOfWork.Complete();

            if(result <= 0) return BadRequest(new ApiResponse(400));

            return Ok(new ApiResponse(200, new { Device = deviceToSet }));
        }
        

    }
}