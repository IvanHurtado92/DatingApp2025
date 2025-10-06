using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        [HttpGet("bad-request")]
        public IActionResult GetBadRequest() //400
        {
            return BadRequest("Bad request");
        }

        [HttpGet("auth")]
        public IActionResult GetAuth() //401
        {
            return Unauthorized();
        }

        [HttpGet("not-found")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("server-error")]
        public IActionResult GerServerError()
        {
            throw new Exception("Server error");
        }
    }
}