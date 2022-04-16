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
using IqraCommerce.API.Params;
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

        [HttpPost("PaymentInfo")]
        public async Task<IActionResult> GetPayment(OrderToCalcPaymentDto orderToCalcPaymentDto)
        {
            var paymentInfo = await _service.CalculatePaymentAsync(orderToCalcPaymentDto);

            if(paymentInfo is null) return BadRequest(new ApiResponse(404, "Address Not Found"));
            
            return Ok(new ApiResponse(200, paymentInfo));
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderCreateDto orderCreateDto)
        {
            var userId = User.RetrieveIdFromPrincipal();

            var order = await _service.PlaceOrder(orderCreateDto, userId);

            if(order is null) return BadRequest(new ApiResponse(400, "Bad Request"));
            
            return Ok(new ApiResponse(200, order));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] OrderParamsDto param)
        {
            var userId = User.RetrieveIdFromPrincipal();

            var orders = await _service.GetOrdersAsync(param, userId);

            return Ok(new ApiResponse(200, orders));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders(Guid id)
        {
            var userId = User.RetrieveIdFromPrincipal();

            var order = await _repo.GetOrderAsync(userId, id);

            if(order is null) return NotFound(new ApiResponse(404, id, "Order not found"));

            var orderToReturn = _mapper.Map<OrderDetailsDto>(order);

            return Ok(new ApiResponse(200, orderToReturn));
        }
    }
}