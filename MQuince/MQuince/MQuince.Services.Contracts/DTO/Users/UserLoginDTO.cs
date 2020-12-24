using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
