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

        public async Task<IEnumerable<ProductShortDto>> GetRelatedProductsAsync(ProductDetailsDto product)
        {
            var categories = product.Categories;
            var relatedProducts = new List<Product>();

            foreach (var category in categories)
            {
                var products = await _repo.GetProductsByCategoryAsync(category.Id);
                relatedProducts.AddRange(products);

                if(relatedProducts.Count >= 10)
                    break;
            }

            var uniqueProducts  = relatedProducts.Select(p => p).Distinct().Where(p => p.Id != product.Id);
            return _mapper.Map<IEnumerable<ProductShortDto>>(uniqueProducts);
        }

        public async Task<Pagination<ProductShortDto>> GetDiscountedProductsAsync(ProductParamDto paramDto)
        {
            ProductParam param = new ProductParam(OrderBy.Discount, paramDto.Take, paramDto.Index, true);

            var productsFromrepo = await _repo.GetProductsAsync(param);

            var productsCount = await _repo.CountAsync(param);

            var productsToReturn = _mapper.Map<IReadOnlyList<ProductShortDto>>(productsFromrepo);

            return new Pagination<ProductShortDto>(param.Index,
                                                    param.Take,
                                                    productsCount,
                                                    productsToReturn);
        }
    }
}