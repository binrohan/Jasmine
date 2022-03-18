using System;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.Miscellaneous
{
    public class ContactsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ContactsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactCreateDto recordToCreate)
        {
            var record = _mapper.Map<Contact>(recordToCreate);

            record.CreatedAt = DateTime.Now;
            record.Id = Guid.NewGuid();
            // Add user if exist

            _unitOfWork.Repository<Contact>().Add(record);

            int result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(418, recordToCreate));

            var recordToReturn = _mapper.Map<ContactReturnDto>(record);

            return Ok(new ApiResponse(201, recordToReturn));
        }
    }
}