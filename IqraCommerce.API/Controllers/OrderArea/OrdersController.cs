using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.ProductArea
{
    public class OrdersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repo;
        private readonly IOrderService _service;
        public OrdersController(IMapper mapper, IOrderRepository repo, IOrderService service)
        {
            _service = service;
            _repo = repo;
            _mapper = mapper;
        }
    }
}