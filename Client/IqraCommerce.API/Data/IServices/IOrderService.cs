using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;

namespace IqraCommerce.API.Data.IServices
{
    public interface IOrderService
    {
        Task<OrderPaymentDto> CalculatePaymentAsync(IOrderToCalcPaymentDto orderToCalcPayment, Guid customerId);
        Task<OrderReturnDto> PlaceOrder(OrderCreateDto orderCreateDto, Guid customerId);
        Task<Pagination<OrderShortDto>> GetOrdersAsync(OrderParamsDto paramDto, Guid customerId);
        Task<OrderDetailsDto> GetOrderAsync(Guid customerId, Guid id);
        void AddOrderCancelHistory(Order order);
    }
}