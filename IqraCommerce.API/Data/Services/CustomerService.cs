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
    public class CustomerService : ICustomerService
    {
        private readonly IAddressRepository _addressRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IAddressRepository addressRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addressRepo = addressRepo;
        }

        public async Task<IEnumerable<AddressReturnDto>> GetAddressesAsync(Guid customerId)
        {
            var addressesFromRepo = await _addressRepo.GetAddressesByCustomerAsync(customerId);

            return _mapper.Map<IEnumerable<AddressReturnDto>>(addressesFromRepo);
        }

        public async Task<AddressReturnDto> GetAddressesAsync(Guid customerId, AddressType addressType)
        {
            var addressFromRepo = await _addressRepo.GetAddressAsync(customerId, addressType);

            return _mapper.Map<AddressReturnDto>(addressFromRepo);
        }

        public async Task<int> UpdateAddressAsync(Guid customerId, AddressUpdateDto addressToUpdate)
        {
            var addressFromRepo = await _addressRepo.GetAddressesByCustomerAsync(customerId);

            foreach (var address in addressFromRepo)
            {
                if (addressToUpdate.IsPrimary && address.Id != addressToUpdate.Id)
                    address.IsPrimary = false;

                if (address.Id == addressToUpdate.Id)
                    _mapper.Map(addressToUpdate, address);
            }

            return await _unitOfWork.Complete();
        }
    }
}