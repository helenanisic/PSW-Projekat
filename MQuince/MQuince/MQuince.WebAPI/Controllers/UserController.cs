using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using MQuince.Entities.Authentication;
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
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = Email,
                Password = Password
            };

            AuthenticateResponse authenticatedUser = _userService.Authenticate(user);
            if (authenticatedUser == null)
            {
                return Unauthorized();
            }
            else
            {

                return Ok(authenticatedUser);
            }
        }
    }
}