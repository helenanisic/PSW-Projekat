using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController([FromServices] IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult AuthenticateUser(string Email, string Password)
        {
            UserLoginDTO user = new UserLoginDTO() { Email = Email, Password = Password };
            bool authenticatedUser = _userService.AuthenticateUser(user);
            if (authenticatedUser == true)
            {
                return Ok(authenticatedUser);
            }
            else
            {
                return BadRequest(authenticatedUser);
            }
        }
    }
}