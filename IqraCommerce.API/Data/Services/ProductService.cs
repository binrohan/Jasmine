using System;
using System.Collections.Generic;
using System.Linq;
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

namespace IqraCommerce.API.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IEnumerable<ProductShortDto>> GetLatestProductsAsync()
        {
            ProductParam param = new ProductParam(OrderBy.CreationDate, 10, true);

            var productsFromrepo = await _repo.GetProductsAsync(param);

            return _mapper.Map<IEnumerable<ProductShortDto>>(productsFromrepo);
        }

        public async Task<IEnumerable<HighlightedProductDto>> GetHighlightedProductsAsync()
        {
            ProductParam param = new ProductParam(OrderBy.Rank)
            {
                IsHighlighted = true
            };

            var productsFromrepo = await _repo.GetProductsAsync(param);

            return _mapper.Map<IEnumerable<HighlightedProductDto>>(productsFromrepo);
        }

        public async Task<IEnumerable<ProductShortDto>> GetTopDiscountedProductsAsync()
        {
            ProductParam param = new ProductParam(OrderBy.Discount, 10, true);

            var productsFromrepo = await _repo.GetProductsAsync(param);

            return _mapper.Map<IEnumerable<ProductShortDto>>(productsFromrepo);
        }
    }
}