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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IqraCommerce.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IDeviceRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpRequest _request;
        public ActivitiesController(
                                  IDeviceRepository repo,
                                  IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  IHttpContextAccessor httpContextAccessor
                                  )
        {
            _mapper = mapper;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _request = httpContextAccessor.HttpContext.Request;
        }

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetActivityId(Guid deviceId)
        {
            var  activity = new Activity()
                    {
                        DeviceId = deviceId,
                        UserId = User?.RetrieveIdFromPrincipal() ?? Guid.Empty,
                        Authority = Request.GetTypedHeaders().Referer.ToString(),
                        DnsSafeHost = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString(),//DnsSafeHost = Request.Url.DnsSafeHost,
                        Host = _request.Host.Value, // Request.Url.Host,
                        UrlReferrer = Request.Headers["Referer"].ToString(),
                        UserAgent = Request.Headers["User-Agent"].ToString(),
                        UserHostAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                        UserHostName = _httpContextAccessor.HttpContext.Request.Host.Value
                    };
            
            _unitOfWork.Repository<Activity>().Add(activity);

            var result = await _unitOfWork.Complete();

            if(result <= 0) return BadRequest(new ApiResponse(400));

            return Ok(new ApiResponse(201, activity.Id));
        }
        

    }
}