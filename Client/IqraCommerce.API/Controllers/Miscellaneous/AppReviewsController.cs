using System;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.Miscellaneous
{
    public class AppReviewsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppReviewRepository _repo;
        private readonly IAppReviewService _service;
        public AppReviewsController(IMapper mapper,
                                    IUnitOfWork unitOfWork,
                                    IAppReviewRepository repo,
                                    IAppReviewService service)
        {
            _service = service;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostReview(AppReviewCreateDto reviewToCreateDto)
        {
            var reviewToCreate = _mapper.Map<AppReview>(reviewToCreateDto);
            reviewToCreate.CustomerId = User.RetrieveIdFromPrincipal();

            _unitOfWork.Repository<AppReview>().Add(reviewToCreate);

            var result = await _unitOfWork.Complete();

            if(result <= 0) return BadRequest(new ApiResponse(400));

            var reviewFromRepo = await _repo.GetAppReviewAsync(reviewToCreate.Id);

            var reviewToReturn = _mapper.Map<AppReviewReturnDto>(reviewFromRepo);

            return Ok(new ApiResponse(201, reviewToReturn));
        }

        [Authorize]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var reviewFromRepo = await _unitOfWork.Repository<AppReview>().GetByIdAsync(id);

            if(reviewFromRepo is null) return NotFound(new ApiResponse(404, "Review not found"));

            if(reviewFromRepo.IsDeleted) return BadRequest(new ApiResponse(405, "Review Already deleted"));

            if(reviewFromRepo.CustomerId != User.RetrieveIdFromPrincipal()) 
                return BadRequest(new ApiResponse(401, "Unauthorized to delete"));

            reviewFromRepo.IsDeleted = true;

            var result = await _unitOfWork.Complete();

            if(result <= 0) return BadRequest(new ApiResponse(400));

            return Ok(new ApiResponse(205, "Review Deleted Successfully"));
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews([FromQuery]AppReviewParamDto param)
        {
            param.CustomerId = User.RetrieveIdFromPrincipal();

            var reviews = await _service.GetAppReivewsAsync(param);

            return Ok(new ApiResponse(200, reviews));
        }

        [HttpGet("{id}")]
        private async Task<IActionResult> GetReview(Guid id)
        {
            var reviewFromRepo = await _repo.GetAppReviewAsync(id);

            var reviewForReturn = _mapper.Map<AppReviewReturnDto>(reviewFromRepo);

            return Ok(new ApiResponse(200, reviewForReturn));
        }
    }
}