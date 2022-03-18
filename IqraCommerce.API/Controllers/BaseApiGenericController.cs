using System;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseApiGenericController<TEntity, TCreate, TUpdate, TReturn> : ControllerBase 
        where TEntity : BaseEntity
        where TCreate : BaseCreateDto 
        where TUpdate : BaseUpdateDto
        where TReturn : BaseDto
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BaseApiGenericController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TCreate recordToCreate)
        {
            var record = _mapper.Map<TEntity>(recordToCreate);

            record.CreatedAt = DateTime.Now;
            record.Id = Guid.NewGuid();
            // Add user if exist

            _unitOfWork.Repository<TEntity>().Add(record);

            int result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(418, recordToCreate));

            var recordToReturn = _mapper.Map<TReturn>(record);

            return Ok(new ApiResponse(201, recordToReturn));
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TUpdate recordToUpdate)
        {
            var recordFromRepo = await _unitOfWork.Repository<TEntity>().GetByIdAsync(recordToUpdate.Id);

            if (recordFromRepo is null)
                return NotFound(new ApiResponse(404));

            _mapper.Map(recordToUpdate, recordFromRepo);
            recordFromRepo.UpdatedAt = DateTime.Now;
            // Add user id if exist

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(418, recordToUpdate));

            var recordToReturn = _mapper.Map<TReturn>(recordFromRepo);

            return Ok(new ApiResponse(200));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ToggleDelete(Guid id)
        {
            var recordFromRepo = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);

            if (recordFromRepo is null)
                return NotFound(new ApiResponse(404));

            recordFromRepo.IsDeleted = !recordFromRepo.IsDeleted;
            recordFromRepo.UpdatedAt = DateTime.Now;

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(418, new {Id = id}));

            if(recordFromRepo.IsDeleted)
                return Ok(new ApiResponse(204, null, "Record delete successful"));

            return Ok(new ApiResponse(204, null, "Record restore successful"));
        }
    }
}