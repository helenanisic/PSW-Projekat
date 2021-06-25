using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Services.Contracts.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public Usertype UserType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
