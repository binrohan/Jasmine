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
    public class DistrictsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _repo;
        public DistrictsController(IMapper mapper, IDistrictRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("ByProvince/{provinceId}")]
        public async Task<IActionResult> GetDistricts(Guid provinceId)
        {
            var districtsFromRepo = await _repo.GetDistrictsByProvinceAsync(provinceId);

            var districtsToReturn = _mapper.Map<IEnumerable<DistrictReturnDto>>(districtsFromRepo);

            return Ok(new ApiResponse(200, districtsToReturn));
        }
    }
}