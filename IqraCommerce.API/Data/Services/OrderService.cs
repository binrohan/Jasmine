using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IqraCommerce.API.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressRepository _addressRepo;

        public OrderService(IConfiguration config, IMapper mapper, IOrderRepository repo, IProductRepository productRepo, IUnitOfWork unitOfWork, IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
            _unitOfWork = unitOfWork;
            _productRepo = productRepo;
            _repo = repo;
            _mapper = mapper;
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public async Task<object> CalculatePaymentAsync(OrderToCalcPaymentDto orderToCalcPayment)
        {
            var listOfProductId = orderToCalcPayment.Products.Select(p => p.Id);
            var products = await _productRepo.GetProductsAsync(listOfProductId);

            var address = await _addressRepo.GetAddressAsync(orderToCalcPayment.AddressId);

            if (address is null) return null;

            var productAmount = products.Amount(orderToCalcPayment.Products);
            var productDiscount = products.Discount(orderToCalcPayment.Products);
            var orderValue = products.Value(orderToCalcPayment.Products);
            var shippingCharges = address.ShippingCharge(orderValue);

            return new OrderPaymentDto(orderValue,
                                       productAmount,
                                       productDiscount,
                                       0,
                                       0,
                                       shippingCharges);
        }
    }
}