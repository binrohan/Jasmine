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
    public class CashbackRegisterService : ICashbackRegisterService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICashbackRegisterRepository _repo;

        public CashbackRegisterService(IMapper mapper, IUnitOfWork unitOfWork, ICashbackRegisterRepository repo)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CashbackRegister> GetByOrderIdAsync(Guid id)
        {
            return await _repo.GetByOrderIdAsync(id);
        }

        public void Register(CashbackServiceDto cashback, Guid customerId, Guid orderId)
        {
            if (cashback.CashbackAmount <= 0.0) return;

            var register = new CashbackRegister()
            {
                ActivityId = Guid.Empty,
                Amount = cashback.CashbackAmount,
                CreatedAt = DateTime.Now,
                CreatedBy = customerId,
                CustomerId = customerId,
                OrderId = orderId,
                RefCashbackId = cashback.Id,
                Status = CashbackRegisterStatus.Pending,
            };

            _unitOfWork.Repository<CashbackRegister>().Add(register);
        }
    }
}