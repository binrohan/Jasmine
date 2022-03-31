using System.Collections.Generic;
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
    public class BrandsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;
        public BrandsController(IMapper mapper, IProductRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brandsFromRepo = await _repo.GetBrandsAsync();

            var brandDict = brandsFromRepo.CreateDict();

            var brandsToReturn  = new BrandsReturnDto(brandDict);

            return Ok(new ApiResponse(200, brandsToReturn, "Successed"));
        }
    }
}