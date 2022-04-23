using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.LocationArea
{
    [Authorize]
    public class ProvincesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _repo;
        public ProvincesController(IMapper mapper, IProvinceRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProvinces()
        {
            var provincesFromRepo = await _repo.GetProvincesAsync();

            var provincesToReturn = _mapper.Map<IEnumerable<ProvinceReturnDto>>(provincesFromRepo);

            return Ok(new ApiResponse(200, provincesToReturn));
        }
    }
}