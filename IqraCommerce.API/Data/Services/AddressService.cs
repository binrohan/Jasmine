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

        public async Task<IEnumerable<AddressReturnDto>> GetAddressesByCustomerAsync(Guid customerId)
        {
            var addresses = new List<AddressReturnDto>();
            var addressesFromRepo = await _addressRepo.GetAddressesByCustomerAsync(customerId);

            foreach (var address in addressesFromRepo)
            {
                addresses.Add(await GenerateAddressReturnDto(address));
            }

            return addresses;
        }

        public async Task<AddressReturnDto> GetAddressAsync(Guid customerId, AddressType addressType)
        {
            var addressFromRepo = await _addressRepo.GetAddressAsync(customerId, addressType);

            return await GenerateAddressReturnDto(addressFromRepo);
        }

        private async Task<AddressReturnDto> GenerateAddressReturnDto(CustomerAddress address)
        {
            var provinceFromRepo = await _unitOfWork.Repository<Province>().GetByIdAsync(address.ProvinceId);
            var districtFromRepo = await _unitOfWork.Repository<District>().GetByIdAsync(address.DistrictId);
            var upazilaFromRepo = await _unitOfWork.Repository<Upazila>().GetByIdAsync(address.UpazilaId);

            var addressReturnDto = _mapper.Map<AddressReturnDto>(address);

            if(provinceFromRepo is not null)
            {
                provinceFromRepo = (provinceFromRepo.IsDeleted
                                || !provinceFromRepo.IsVisible) ? null : provinceFromRepo;
            }

            if(districtFromRepo is not null)
            {
                districtFromRepo = (districtFromRepo.IsDeleted
                                || !districtFromRepo.IsVisible) ? null : districtFromRepo;
            }
            
            if(upazilaFromRepo is not null)
            {
                upazilaFromRepo = (upazilaFromRepo.IsDeleted
                                || !upazilaFromRepo.IsVisible) ? null : upazilaFromRepo;
            }
            
            addressReturnDto.Province = _mapper.Map<ProvinceReturnDto>(provinceFromRepo);
            addressReturnDto.District = _mapper.Map<DistrictReturnDto>(districtFromRepo);
            addressReturnDto.Upazila = _mapper.Map<UpazilaReturnDto>(upazilaFromRepo);

            return addressReturnDto;
        }
    }
}