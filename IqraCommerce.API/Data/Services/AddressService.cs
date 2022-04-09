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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IAddressRepository addressRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addressRepo = addressRepo;
        }
    }
}