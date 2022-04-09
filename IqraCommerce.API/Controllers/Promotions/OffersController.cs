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
    [Authorize]
    public class OffersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _repo;
        public OffersController(IMapper mapper, IOfferRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOffers()
        {
            var offersFromRepo = await _repo.GetOffersAsync();
            var offersToReturn  = _mapper.Map<IEnumerable<OfferReturnDto>>(offersFromRepo);;

            return Ok(new ApiResponse(200, offersToReturn, "Successed"));
        }
    }
    
}