using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.Services
{
    public class PaymentHistoryService : IPaymentHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentHistoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCashbackPayment(Order order)
        {
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(order.CustomerId);

            if(customer?.Cashback <= 0) return;

            var withdraw = order.PayableAmount > customer.Cashback ? customer.Cashback : order.PayableAmount;

            order.PaidAmount += withdraw;
            customer.Cashback -= withdraw;

            var history = new PaymentHistory()
            {
                ActivityId = order.ActivityId,
                Amount = withdraw,
                CreatedAt = DateTime.Now,
                CreatedBy = order.CustomerId,
                CustomerId = order.CustomerId,
                Medium = PaymentMedium.Cashback,
                OrderId = order.Id,
                Reference = "N/A",
                Remarks = "Partial Payment from customer cashback",
            };

            OrderHistory orderHistory = new OrderHistory()
            {
                ActivityId = order.ActivityId,
                CreatedAt = DateTime.Now,
                CreatedBy = order.CustomerId,
                Remarks = "Order initial payment made from customer cashback account",
                OrderId = order.Id,
                TypeOfAction = OrderAction.PaymentStatusChanged,
                Name = $"Payment status changed from {PaymentStatus.Pending} To {PaymentStatus.InitialFromCashback}. Withdraw amount {withdraw}Tk"
            };

            _unitOfWork.Repository<PaymentHistory>().Add(history);
            _unitOfWork.Repository<OrderHistory>().Add(orderHistory);
        }
    }
}