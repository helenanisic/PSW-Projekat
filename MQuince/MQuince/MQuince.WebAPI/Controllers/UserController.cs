﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

            var result = _userService.Authenticate(user);
            if (result.IsFailure)
                return Unauthorized(result.Error);
            return Ok(result.Value);
            
        }

        [HttpGet("GetRole")]
        [Authorize]
        public IActionResult GetRole()
        {
            string token = Request.Headers["Authorization"];
            var role = _userService.GetRoleFromJwtToken(token.Split(" ")[1]);
            return Ok(role);
        }
    }
}