using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.ProductArea
{
    public class CategoriesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly ICategoryService _service;

        public CategoriesController(IMapper mapper, ICategoryRepository repo, ICategoryService service)
        {
            _service = service;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesFromRepo = await _repo.GetCategoriesAsync();

            var categoriesToReturn = categoriesFromRepo.CreateHierarchicalOrder();

            return Ok(new ApiResponse(200, categoriesToReturn));
        }

        [HttpGet("ChildrenWithProducts/{categoryId}")]
        public async Task<IActionResult> GetChildCategoriesWithProducts(Guid categoryId)
        {
            var categoriesFromRepo = await _repo.GetChildCategoriesWithProductsAsync(categoryId);

            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryWithProductDto>>(categoriesFromRepo);

            return Ok(new ApiResponse(200, categoriesToReturn));
        }


        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            var categoryId = Guid.Parse("5b8aa954-8b13-4e7f-83eb-3c32841ea1ec");

            var categoriesFromRepo = await _service.GetChildrenWithProducts(categoryId);

            // var categoriesToReturn = _mapper.Map<IEnumerable<CategoryWithProductDto>>(categoriesFromRepo);

            return Ok(new ApiResponse(200, categoriesFromRepo));
        }
    }
}