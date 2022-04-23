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
    public class FestivalsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IFestivalRepository _repo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IFestivalService _service;
        private readonly IUnitOfWork _unitOfWork;
        public FestivalsController(IMapper mapper,
                                  IFestivalRepository repo,
                                  ICategoryRepository categoryRepo,
                                  IUnitOfWork unitOfWork,
                                  IFestivalService service)
        {
            _service = service;
            _unitOfWork = unitOfWork;
            _repo = repo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFestivalsWithProduct()
        {
            var festivals = await _service.GetFestivalsWithProductsAsync();

            return Ok(new ApiResponse(200, festivals));
        }

    }
}