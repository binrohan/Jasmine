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
    }
}