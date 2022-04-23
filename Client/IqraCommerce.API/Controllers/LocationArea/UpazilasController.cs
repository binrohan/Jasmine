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
    public class UpazilasController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUpazilaRepository _repo;
        public UpazilasController(IMapper mapper, IUpazilaRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("ByDistrict/{districtId}")]
        public async Task<IActionResult> GetUpazilas(Guid districtId)
        {
            var upazilasFromRepo = await _repo.GetUpazilasByDistrictAsync(districtId);

            var upazilasToReturn = _mapper.Map<IEnumerable<UpazilaReturnDto>>(upazilasFromRepo);

            return Ok(new ApiResponse(200, upazilasToReturn));
        }
    }
}