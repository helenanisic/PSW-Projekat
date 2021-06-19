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
        [Required]
        public Guid Id { get; set; }
        public Usertype UserType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(Usertype userType, string name, string surname, string email, string password) : this(Guid.NewGuid(), userType, name, surname, email, password) { }
        public User(Guid id, Usertype userType, string name, string surname, string email, string password)
        {
            Id = id;
            UserType = userType;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
    }
}
