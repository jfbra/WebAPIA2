using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIA2.Data;
using WebAPIA2.Dtos;
using WebAPIA2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPIA2.Controllers
{
    [Route("api")]
    [ApiController]
    public class VersionController : Controller
    {
        private readonly IAuthRepo _repository;

        public VersionController(IAuthRepo repository)
        {
            _repository = repository;
        }

        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetVersionA")]
        public ActionResult<string> ViewVersion()
        {
            return Ok("v1");
        }
    }
}
