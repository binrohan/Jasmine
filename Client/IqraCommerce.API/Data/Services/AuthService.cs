using System;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IOTPService _otpService;
        public AuthService(ICustomerRepository repo, IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IOTPService otpService)
        {
            _otpService = otpService;
            _tokenService = tokenService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public async Task<bool> CheckPasswordSignInAsync(Customer customer, string password)
        {
            var customerFromRepo = await _unitOfWork.Repository<Customer>().GetByIdAsync(customer.Id);

            return customerFromRepo.Password == password && customerFromRepo.Phone == customer.Phone;
        }

        public async Task<CustomerAuthDto> RegisterAsync(RegisterDto register)
        {
            var customer = _mapper.Map<Customer>(register);

            _unitOfWork.Repository<Customer>().Add(customer);

            var registerFromRepo = await _unitOfWork.Repository<Register>()
                                                    .GetByIdAsync(register.RequestId);
            
            registerFromRepo.CustomerId = customer.Id;
            registerFromRepo.IsPassed = true;

            
            _unitOfWork.Repository<CustomerAddress>().Add(new CustomerAddress
            {
                TypeOfAddress = AddressType.Home,
                CustomerId = customer.Id,
                IsPrimary = true
            });
            _unitOfWork.Repository<CustomerAddress>().Add(new CustomerAddress
            {
                TypeOfAddress = AddressType.HomeTown,
                CustomerId = customer.Id
            });
            _unitOfWork.Repository<CustomerAddress>().Add(new CustomerAddress
            {
                TypeOfAddress = AddressType.Office,
                CustomerId = customer.Id
            });
            _unitOfWork.Repository<CustomerAddress>().Add(new CustomerAddress
            {
                TypeOfAddress = AddressType.Recent,
                CustomerId = customer.Id
            });
            


            var result = await _unitOfWork.Complete();

            if (result == 0) return null;

            var customerToReturn = _mapper.Map<CustomerAuthDto>(customer);
            customerToReturn.Token = _tokenService.CreateToken(customer);

            return customerToReturn;
        }

        public async Task<int> ResetPasswordAsync(string phone, string password)
        {
            var customerFromRepo = await _repo.FindByPhoneAsync(phone);

            if(customerFromRepo is null) return -1;

            customerFromRepo.Password = password;

            var result = await _unitOfWork.Complete();

            return result;
        }
    }
}