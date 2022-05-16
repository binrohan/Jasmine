using System;
using System.Collections.Generic;
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
    [Authorize]
    public class NotificationsController : BaseApiController
    {
        private readonly INotificationService _service;
        private readonly INotificationRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(INotificationService service,
                                  IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  INotificationRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
            _service = service;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetUnseenNotificationCount()
        {
            var userId = User.RetrieveIdFromPrincipal();

            var count = await _repo.GetUnseenNotificationCountAsync(userId);

            return Ok(new ApiResponse(200, count));
        }

        [HttpGet("MarkAsUnseen")]
        public async Task<IActionResult> MarksAsSeen([FromQuery]IList<Guid> ids)
        {
            var userId = User.RetrieveIdFromPrincipal();

            var result = await _service.MarkNotificationAsSeenAsync(ids, userId);

            if(result <= 0) return BadRequest(new ApiResponse(400));
            
            return Ok(new ApiResponse(200, "Successfully marked as seen"));
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications([FromQuery]NotificationParamsDto param)
        {
            var userId = User.RetrieveIdFromPrincipal();

            var notifications = await _service.GetNotificationsAsync(param, userId);

            return Ok(new ApiResponse(200, notifications));
        }
    }
}