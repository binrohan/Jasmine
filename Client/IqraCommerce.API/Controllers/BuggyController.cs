using System;
using IqraCommerce.API.Data;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText() 
        {
            return "secret stuff";
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _context.Contact.Find(Guid.NewGuid());

            if (thing == null) return NotFound(new ApiResponse(404));

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Contact.Find(new ApiResponse(404));

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400, new {Errors = "GetBadRequest"}));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

        [HttpPost("validationError")]
        public ActionResult ValidationError(BugDto bugDto)
        {
            return Ok();
        }
    }
}