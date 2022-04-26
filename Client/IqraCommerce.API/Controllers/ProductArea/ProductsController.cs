using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using IqraCommerce.API.Data.IServices;

namespace IqraCommerce.API.Controllers.ProductArea
{
    public class ProductsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductService _service;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IMapper mapper,
                                  IProductRepository repo,
                                  ICategoryRepository categoryRepo,
                                  IUnitOfWork unitOfWork,
                                  IProductService service)
        {
            _service = service;
            _unitOfWork = unitOfWork;
            _repo = repo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;

        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var productFromRepo = await _repo.GetProductAsync(productId);

            if(productFromRepo is null) return NotFound(new ApiResponse(404));

            var categoriesFromRepo = await _categoryRepo.GetCategoriesByProductAsync(productId);

            var productToReturn = _mapper.Map<ProductDetailsDto>(productFromRepo);
            productToReturn.Categories = _mapper.Map<IEnumerable<CategoryShortDto>>(categoriesFromRepo);

            return Ok(new ApiResponse(200, productToReturn));
        }

        [HttpGet("Highlighted")]
        public async Task<IActionResult> GetHighlightedProducts()
        {
            var products = await _service.GetHighlightedProductsAsync();

            return Ok(new ApiResponse(200, products));
        }

        [HttpGet("TopDiscounted")]
        public async Task<IActionResult> GetTopDiscountedProducts()
        {
            var products = await _service.GetTopDiscountedProductsAsync();

            return Ok(new ApiResponse(200, products));
        }
    }
}