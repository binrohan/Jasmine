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
    [Authorize]
    public class ComplainsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ComplainsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostComplain(ComplainCreateDto complainToCreate)
        {
            var complain = _mapper.Map<Complain>(complainToCreate);

            complain.CreatedAt = DateTime.Now;
            complain.CreatedBy = User.RetrieveIdFromPrincipal();

            _unitOfWork.Repository<Complain>().Add(complain);

            int result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(418, complainToCreate));

            var recordToReturn = _mapper.Map<ComplainReturnDto>(complain);

            return Ok(new ApiResponse(201, recordToReturn));
        }
    }
}