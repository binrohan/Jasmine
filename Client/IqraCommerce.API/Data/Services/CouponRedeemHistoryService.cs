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
    public class CouponRedeemHistoryService : ICouponRedeemHistoryService
    {
        private readonly ICouponRedeemHistoryRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CouponRedeemHistoryService(ICouponRedeemHistoryRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task AddHistoryAsync(OrderPaymentDto payment, Guid customerId, Guid orderId)
        {
            if(!payment.Coupon.IsLegit)
                return;

            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(payment.Coupon.Id);

            var history = new CouponRedeemHistory()
            {
                ActivityId = Guid.Empty,
                CouponId = payment.Coupon.Id,
                CreatedAt = DateTime.Now,
                CreatedBy = customerId,
                CustomerId = customerId,
                Remarks = GenerateHistoryMessage(coupon.Discount,
                                                 payment.OrderValue,
                                                 payment.Coupon.Discount,
                                                 payment.Coupon.Code),
                Value = payment.Coupon.Discount,
                OrderId = orderId
            };

            _unitOfWork.Repository<CouponRedeemHistory>().Add(history);
        }

        private string GenerateHistoryMessage(double percentage,
                                              double orderValue,
                                              double discount,
                                              string code)
        {
            return $"Redeemed {percentage}% Discount Of Over Value {orderValue} as {discount}TK from code {code}";
        }
    }
}