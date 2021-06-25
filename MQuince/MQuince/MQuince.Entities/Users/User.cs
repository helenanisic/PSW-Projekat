using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Entities
{
    public class User
    {
 
        public Guid Id { get; set; }
        public Usertype UserType { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Banned { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(Usertype userType, string name, string surname, string email, string password, bool banned) : this(Guid.NewGuid(), userType, name, surname, email, password, banned) { }
        public User(Guid id, Usertype userType, string name, string surname, string email, string password, bool banned)
        {
            Id = id;
            UserType = userType;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Banned = banned;
        }
    }
}
