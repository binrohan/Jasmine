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
    public class AquiredOfferService : IAquiredOfferService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AquiredOfferService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddAquiredOffer(OrderPaymentDto payment, Guid orderId)
        {
            if (payment.ProductDiscount > 0)
            {
                _unitOfWork.Repository<OrderAquiredOffer>().Add
               (
                   new OrderAquiredOffer()
                   {
                       OrderId = orderId,
                       Description = "Product discounted price",
                       IsRedeemed = true,
                       RefOfferId = Guid.Empty,
                       TypeOfOffer = OrderAquiredOfferType.Product,
                       Discount = payment.ProductDiscount
                   }
               );
            }

            if (payment.Cashback.CashbackAmount > 0)
            {
               _unitOfWork.Repository<OrderAquiredOffer>().Add
                (
                    new OrderAquiredOffer()
                    {
                        OrderId = orderId,
                        Description = $"Cashback {payment.Cashback.CashbackAmount}Tk for Payment {payment.OrderValue - payment.Coupon.Discount}",
                        IsRedeemed = false,
                        RefOfferId = payment.Cashback.Id,
                        TypeOfOffer = OrderAquiredOfferType.Cashback,
                        Discount = payment.Cashback.CashbackAmount
                    }
                );
            }

            if (payment.Coupon.IsLegit)
            {
                _unitOfWork.Repository<OrderAquiredOffer>().Add
                 (
                     new OrderAquiredOffer()
                     {
                         OrderId = orderId,
                         Description = $"Coupon Code Redemmed: {payment.Coupon.Code}",
                         IsRedeemed = true,
                         RefOfferId = payment.Coupon.Id,
                         TypeOfOffer = OrderAquiredOfferType.Coupon,
                         Discount = payment.Coupon.Discount
                     }
                 );
            }

            
        }
    }
}