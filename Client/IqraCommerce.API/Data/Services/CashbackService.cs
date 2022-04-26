using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.Services
{
    public class CashbackService : ICashbackService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICashbackRepository _repo;

        public CashbackService(ICashbackRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CashbackServiceDto> CalculateAsync(double payAmount)
        {
            var cashback = await _repo.GetCashbackByOrderValueAsync(payAmount);

            if(cashback is null) return new CashbackServiceDto(0.0);

            return new CashbackServiceDto(cashback.Amount, cashback.Id);
        }

        public async Task RedeemAsync(double cashback, Guid customerId)
        {
            if(cashback == 0.0) return;

            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(customerId);

            customer.Cashback += cashback;
        }
    }
}