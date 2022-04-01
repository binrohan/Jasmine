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

        public async Task<IEnumerable<ProductShortDto>> GetLatestProduct(int take)
        {
            take = take > Config.MaxLatestProduct ? Config.MaxLatestProduct : take;

            var productsFromrepo = await _repo.GetLatestProducts(take);

            return _mapper.Map<IEnumerable<ProductShortDto>>(productsFromrepo);
        }

        public async Task<IEnumerable<HighlightedProductDto>> GetHighlightedProductsAsync()
        {
            var productsFromrepo = await _repo.GetHighlightedProductsAsync();

            return _mapper.Map<IEnumerable<HighlightedProductDto>>(productsFromrepo);
        }
    }
}