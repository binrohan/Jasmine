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
    public class CashbackHistoryService : ICashbackHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICashbackHistoryRepository _repo;

        public CashbackHistoryService(ICashbackHistoryRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddHistoryAsync(OrderPaymentDto payment, Guid customerId, Guid orderId)
        {
            if (payment.Cashback.CashbackAmount == 0.0) return;

            var cashbackFromRepo = await _unitOfWork.Repository<Cashback>().GetByIdAsync(payment.Cashback.Id);

            var history = new CashbackHistory()
            {
                ActivityId = Guid.Empty,
                CreatedAt = DateTime.Now,
                CreatedBy = customerId,
                Amount = payment.Cashback.CashbackAmount,
                CustomerId = customerId,
                IsRedeemed = false,
                OrderId = orderId,
                Remarks = GenerateMessage(payment.Cashback.CashbackAmount,
                                          payment.OrderValue - payment.Coupon.Discount - payment.ShippingCharge)
            };
                await _unitOfWork.Repository<Cashback>().GetByIdAsync(payment.Cashback.Id);
           }

        private string GenerateMessage(double cashback, double payment)
        {
            return $"Pending {cashback} after placed order with payment {payment}";
        }
    }
}