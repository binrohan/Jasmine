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
    [Authorize]
    public class NotificationController : BaseApiController
    {
        private readonly INotificationService _service;
        private readonly INotificationRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationController(INotificationService service,
                                  IMapper mapper,
                                  IUnitOfWork unitOfWork,
                                  INotificationRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
            _service = service;
            _unitOfWork = unitOfWork;
        }
    }
}