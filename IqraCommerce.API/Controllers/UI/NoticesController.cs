using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs.Notice;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.UI
{
    public class NoticesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUIRepository _repo;
        public NoticesController(IMapper mapper, IUIRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotices()
        {
            var noticesFromRepo = await _repo.GetNoticesAsync();
            var noticesToReturn  = _mapper.Map<IEnumerable<NoticeReturnDto>>(noticesFromRepo);

            return Ok(new ApiResponse(200, noticesToReturn, "Successed"));
        }
    }
    
}