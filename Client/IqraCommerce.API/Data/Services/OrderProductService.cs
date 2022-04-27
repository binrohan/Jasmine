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
    public class OrderProductService : IOrderProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepo;

        public OrderProductService(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepo)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(IEnumerable<OrderProductDto> products, Guid orderId)
        {
            var productsFromRepo = await GetProductsByProductDtoAsync(products);
            var productsForOrder = new List<OrderProduct>();
            
            foreach (var product in productsFromRepo)
            {
                var orderProduct = _mapper.Map<OrderProduct>(product);

                orderProduct.OrderId = orderId;

                var orderedProduct = products.First(p => p.Id == product.Id);

                orderProduct.Quantity = orderedProduct.Quantity;
                orderProduct.Amount = orderedProduct.Quantity * product.CurrentPrice;
                orderProduct.Discount = orderedProduct.Quantity * product.DiscountedPrice;

                productsForOrder.Add(orderProduct);
            }

            _unitOfWork.Repository<OrderProduct>().AddRange(productsForOrder);
        }

        private async Task<IEnumerable<Product>> GetProductsByProductDtoAsync(IEnumerable<OrderProductDto> products)
        {
            var listOfProductId = products.Select(p => p.Id);
            return await _productRepo.GetProductsAsync(listOfProductId);
        }
    }
}