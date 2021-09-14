using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIA2.Models;
using WebAPIA2.Data;
using WebAPIA2.Dtos;

namespace WebAPIA2.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersAPIRepo _repository;

        public UsersController(IUsersAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> RegisterUserAsync(UserRegInputDto user)
        {
            if (user.UserName == "")
                return Ok("Invalid username");

            string return_message;
            User u = new User
            {
                UserName = user.UserName,
                Password = user.Password,
                Address = user.Address
            };
            bool result = await _repository.CheckUserAsync(u);
            if (result == true)
            {
                await _repository.AddUserAsync(u);
                return_message = "User successfully registered.";
            }
            else
            {
                return_message = "Username not available.";
            }
            return Ok(return_message);
        }
    }
}
