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
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _repo;
        private readonly ICouponRedeemHistoryRepository _couponHistoryRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CouponService(ICouponRepository repo,
                             IMapper mapper,
                             IUnitOfWork unitOfWork,
                             ICouponRedeemHistoryRepository couponHistoryRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repo = repo;
            _couponHistoryRepo = couponHistoryRepo;
        }

        public async Task<CouponRedemtionDto> DiscountAsync(double orderValue, string code, Guid customerId)
        {
            var redemtion = new CouponRedemtionDto(code);

            var coupon = await _repo.GetCouponByCodeAsync(code);

            if(coupon is null) return redemtion.SetDiscount(0.0, "No coupon availble");

            redemtion.Id = coupon.Id;

            var left = coupon.Count - coupon.Redeemed;
            if(coupon.IsLimited && left <= 0)
                return redemtion.SetDiscount(0.0, "No more coupon avaible");
            
            var couponHistory = await _couponHistoryRepo.GetCouponHistoryByCustomer(coupon.Id, customerId);

            if(couponHistory is not null) return redemtion.SetDiscount( 0.0, "Already redeemed");

            if(orderValue - coupon.MinOrderValue <= 0) return redemtion.SetDiscount(0.0, "Minimum order value condition not meet");

            var discount = orderValue * (coupon.Discount / 100);
            discount = (discount > coupon.MaxDiscount && coupon.MaxDiscount!= 0) ? coupon.MaxDiscount : discount;
            discount = discount < coupon.MinDiscount ? coupon.MinDiscount : discount;

            return redemtion.SetDiscount(discount, "Coupon Redeemed");
        }

        public async Task RedeemAsync(Guid id)
        {
           var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(id);

            if(coupon is null) return;

            ++coupon.Redeemed;
        }
    }
}