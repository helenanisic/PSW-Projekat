using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using MQuince.Entities;
using MQuince.Entities.Authentication;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using Newtonsoft.Json;

namespace MQuince.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly string secret;
        public UserService(IUserRepository userRepository, string secret)
        {
            _userRepository = userRepository;
            this.secret = secret;
        }

        public Result<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.AuthenticateUser(model);
            if(user == null)
            {
                return Result.Failure<AuthenticateResponse>("Wrong email or password");
            }
            if(user.Banned == true)
            {
                return Result.Failure<AuthenticateResponse>("You are blocked!");
            }
            else
            {
                var token = generateJwtToken(user);

                return Result.Success<AuthenticateResponse>(new AuthenticateResponse(user, token));
            }

        }


        public User GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }


        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Id.ToString()), new Claim(ClaimTypes.Role, user.UserType.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetIdFromJwtToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return claims.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault().ToString();
        }

        public string GetRoleFromJwtToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return claims.Claims.Where(c => c.Type == ClaimTypes.Role)
                   .Select(c => c.Value).SingleOrDefault().ToString();
        }

    }
}
