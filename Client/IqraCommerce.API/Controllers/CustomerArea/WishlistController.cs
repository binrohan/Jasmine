using System;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Constants;
using IqraCommerce.API.Data;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IqraCommerce.API.Controllers
{
    [Authorize]
    public class WishlistController : BaseApiController
    {
        private readonly IWishlistRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public WishlistController(
                                  IWishlistRepository repo,
                                  IMapper mapper,
                                  IUnitOfWork unitOfWork
                                  )
        {
            _mapper = mapper;
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid productId)
        {
            var wishlist = new Wishlist()
            {
                ProductId = productId,
                CustomerId = User.RetrieveIdFromPrincipal()
            };

            _unitOfWork.Repository<Wishlist>().Add(wishlist);

            var result = await _unitOfWork.Complete();

            if(result <= 0) return BadRequest(new ApiResponse(400));

            return Ok(new ApiResponse(201, wishlist));
        }

    }
}