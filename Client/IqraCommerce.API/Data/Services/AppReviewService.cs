using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;
using IqraCommerce.API.Params;

namespace IqraCommerce.API.Data.Services
{
    public class AppReviewService : IAppReviewService
    {
        private readonly IAppReviewRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AppReviewService(IAppReviewRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Pagination<AppReviewReturnDto>> GetAppReivewsAsync(AppReviewParamDto paramDto)
        {
            AppReviewParam param = new AppReviewParam(paramDto.CustomerId, paramDto.Take, paramDto.Index);

            var reviewCount = await _repo.CountAsync(param);

            var reviews = await _repo.GetAppReviewsAsync(param);

            var reviewsToReturn = _mapper.Map<IReadOnlyList<AppReviewReturnDto>>(reviews);

            return new Pagination<AppReviewReturnDto>(param.Index,
                                                param.Take,
                                                reviewCount,
                                                reviewsToReturn);
        }
    }
}