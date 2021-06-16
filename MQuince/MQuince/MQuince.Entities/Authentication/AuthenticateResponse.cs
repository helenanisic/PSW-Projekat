using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Authentication
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.Name;
            LastName = user.Surname;
            Username = user.Email;
            Token = token;
        }
    }
}
