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
        private Guid _id;
        public Usertype UserType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid Id
        {
            get => _id;
            protected set => _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;

        }
        public User()
        {
            _id = Guid.NewGuid();
        }

        public User(Usertype userType, string name, string surname, string email, string password) : this(Guid.NewGuid(), userType, name, surname, email, password) { }
        public User(Guid id, Usertype userType, string name, string surname, string email, string password)
        {
            _id = id;
            UserType = userType;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
    }
}
