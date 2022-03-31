using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.DTOs.Notice;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.AppData;
using Microsoft.AspNetCore.Mvc;
using IqraCommerce.API.Helpers;
using IqraCommerce.API.Entities;
using IqraCommerce.API.DTOs.Category;

namespace IqraCommerce.API.Controllers.HomeArea
{
    public class AppDataController : BaseApiController
    {
        private readonly IUIRepository _uIRepo;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;
        public AppDataController(IMapper mapper, IProductRepository productRepo, IUIRepository uIRepo)
        {
            _uIRepo = uIRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet("CreateAppData")]
        public async Task<IActionResult> CreateAppData()
        {
            var categoriesFrompRepo = await _productRepo.GetCategoriesAsync();
            var categoriesToReturn = categoriesFrompRepo.CreateHierarchicalOrder().ToArray();
            
            var data = await FileCreator.CreateAppData("", categoriesToReturn);

            return Ok(new ApiResponse(200, data, "Successed"));

        }
    }
}