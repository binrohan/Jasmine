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
using Microsoft.AspNetCore.Hosting;

namespace IqraCommerce.API.Controllers.HomeArea
{
    public class AppDataController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AppDataController(IMapper mapper, ICategoryRepository repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _mapper = mapper;
            _hostEnvironment = environment;
        }

        [HttpGet("Create")]
        public async Task<IActionResult> CreateAppData()
        {
            var categoriesFrompRepo = await _repo.GetCategoriesAsync();
            var categoriesToReturn = categoriesFrompRepo.CreateHierarchicalOrder().ToArray();
            
            var data = await FileCreator.CreateAppData("", categoriesToReturn);

            return Ok(new ApiResponse(201, data, "App data created!"));

        }

        [HttpGet("WebRootPath")]
        public string BasePath()
        {
            return _hostEnvironment.WebRootPath;
        }
    }
}