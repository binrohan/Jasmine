using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.DTOs.Notice;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GenerateStatic()
        {
            // Category
            var categoriesFrompRepo = await _productRepo.GetCategoriesAsync();
            var categoriesToReturn = categoriesFrompRepo.CreateHierarchicalOrder();

            var bannersFromRepo = await _uIRepo.GetBannersAsync();
            var bannersToReturn  = _mapper.Map<IEnumerable<BannerReturnDto>>(bannersFromRepo);

            var noticesFromRepo = await _uIRepo.GetNoticesAsync();
            var noticesToReturn  = _mapper.Map<IEnumerable<NoticeReturnDto>>(noticesFromRepo);


            return Ok(new ApiResponse(200, new { }, "Successed"));
        }

        [HttpGet("CreateAppData")]
        public async Task<IActionResult> CreateAppData()
        {
            
            
            var data = await FileCreator.CreateAppData("");

            return Ok(new ApiResponse(200, data, "Successed"));

        }
    }
}