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
        private readonly ICategoryRepository _categoryRepo;

        public ProductService(IProductRepository repo, ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _repo = repo;
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