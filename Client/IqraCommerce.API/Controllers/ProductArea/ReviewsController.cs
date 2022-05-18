using System;
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
    public class ReviewsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewRepository _repo;
        private readonly IReviewService _service;
        public ReviewsController(IMapper mapper,
                                    IUnitOfWork unitOfWork,
                                    IReviewRepository repo,
                                    IReviewService service)
        {
            _service = service;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}