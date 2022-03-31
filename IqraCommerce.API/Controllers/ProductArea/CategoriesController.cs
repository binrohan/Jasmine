using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
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
        public CategoriesController(IMapper mapper, ICategoryRepository repo)
        {
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

        [HttpGet("ChildrenWithProductOf/{categroyId}")]
        public async Task<IActionResult> GetChildCategoriesWithProducts(Guid categroyId)
        {
            var categoriesFromRepo = await _repo.GetChildCategoriesWithProductsAsync(categroyId);

            return Ok(new ApiResponse(200, categoriesFromRepo));
        }
    }
}