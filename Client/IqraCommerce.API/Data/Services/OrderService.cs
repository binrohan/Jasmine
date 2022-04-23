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
using IqraCommerce.API.Params;
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

        public OrderService(IConfiguration config,
                            IMapper mapper,
                            IOrderRepository repo,
                            IProductRepository productRepo,
                            IUnitOfWork unitOfWork,
                            IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
            _unitOfWork = unitOfWork;
            _productRepo = productRepo;
            _repo = repo;
            _mapper = mapper;
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public async Task<OrderPaymentDto> CalculatePaymentAsync(IOrderToCalcPaymentDto orderToCalcPayment)
        {
            var products = await GetProductsByListOfIdAsync(orderToCalcPayment.Products);

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

        public async Task<OrderReturnDto> PlaceOrder(OrderCreateDto orderCreateDto, Guid customerId)
        {
            var payment = await CalculatePaymentAsync(orderCreateDto);

            var matched = payment
               .PublicInstancePropertiesEqual<OrderPaymentDto>(orderCreateDto.Payment);

            if (!matched) return null;


            var order = orderCreateDto.GenerateNewOrder(payment,
                                                        customerId,
                                                        await GenerateOrderNumberAsync());

            _unitOfWork.Repository<Order>().Add(order);

            var productsFromRepo = await GetProductsByListOfIdAsync(orderCreateDto.Products);
            var orderProducts = productsFromRepo.Order(orderCreateDto.Products, order.Id);
            _unitOfWork.Repository<OrderProduct>().AddRange(orderProducts);


            var aquiredOffers = payment.AquiredOffers(order.Id);
            _unitOfWork.Repository<OrderAquiredOffer>().AddRange(aquiredOffers);

            var history = order.OrderInitiateHistory(payment, customerId, "Order Placed");
            _unitOfWork.Repository<OrderHistory>().Add(history);

            var addressFromRepo = await _unitOfWork
                                .Repository<CustomerAddress>()
                                .GetByIdAsync(orderCreateDto.AddressId);

            var shippingAddress = _mapper.Map<ShippingAddress>(addressFromRepo);
            shippingAddress.OrderId = order.Id;
            _unitOfWork.Repository<ShippingAddress>().Add(shippingAddress);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return _mapper.Map<OrderReturnDto>(order);
        }

        public async Task<Pagination<OrderShortDto>> GetOrdersAsync(OrderParamsDto paramDto, Guid customerId)
        {
            OrderParam param = new OrderParam(customerId, paramDto.Index, paramDto.Search, paramDto.IsDecending);

            var totalOrders = await _repo.CountAsync(param);

            var ordersFromRepo = await _repo.GetOrdersAsync(param);

            var ordersToReturn = _mapper.Map<IReadOnlyList<OrderShortDto>>(ordersFromRepo);

            return new Pagination<OrderShortDto>(param.Index,
                                                                param.Take,
                                                                totalOrders,
                                                                ordersToReturn);
        }

        private async Task<string> GenerateOrderNumberAsync()
        {
            var orderCount = (await _unitOfWork.Repository<Order>().ListAllAsync()).Count();

            return DateTime.Now.ToString("MMdd") + orderCount.ToString().PadLeft(3, '0');
        }

        private async Task<IEnumerable<Product>> GetProductsByListOfIdAsync(IEnumerable<OrderProductDto> products)
        {
            var listOfProductId = products.Select(p => p.Id);
            return await _productRepo.GetProductsAsync(listOfProductId);
        }

        public void AddOrderCancelHistory(Order order)
        {
            OrderHistory history = new OrderHistory()
            {
                CreatedAt = DateTime.Now,
                CreatedBy = order.CustomerId,
                ActivityId = order.ActivityId,
                OrderId = order.Id,
                TypeOfAction = OrderAction.CancelledByCustomer,
                Remarks = "Order Cancelled By Customer"
            };

            _unitOfWork.Repository<OrderHistory>().Add(history);
        }
    }
}