using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.UI
{
    public class BannersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUIRepository _repo;
        public BannersController(IMapper mapper, IUIRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBanners()
        {
            var bannersFromRepo = await _repo.GetBannersAsync();
            var bannersToReturn  = _mapper.Map<IEnumerable<BannerReturnDto>>(bannersFromRepo);;

            return Ok(new ApiResponse(200, bannersToReturn, "Successed"));
        }
    }
    
}