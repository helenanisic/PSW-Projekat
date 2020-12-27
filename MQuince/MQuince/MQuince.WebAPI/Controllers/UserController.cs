using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
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
            Guid authenticatedUser = _userService.AuthenticateUser(user);
            if (authenticatedUser.Equals(Guid.Empty))
            {
                return BadRequest(authenticatedUser.ToString());
            }
            else
            { 
                HttpContext.Session.SetString("UserId", authenticatedUser.ToString());
                return Ok(authenticatedUser.ToString());
            }
        }
    }
}