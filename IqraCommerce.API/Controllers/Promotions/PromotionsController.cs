using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.UI
{
    public class PromotionsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IPromotionRepository _repo;
        public PromotionsController(IMapper mapper, IPromotionRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPromotions()
        {
            var PromotionsFromRepo = await _repo.GetPromotionsAsync();
            var PromotionsToReturn  = _mapper.Map<IEnumerable<PromotionReturnDto>>(PromotionsFromRepo);;

            return Ok(new ApiResponse(200, PromotionsToReturn, "Successed"));
        }
    }
    
}