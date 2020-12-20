using MQuince.Entities.Rooms;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Doctor : User
    {
        public Specialization Specialization { get; set; }

        public Doctor(Usertype userType, string name, string surname, string email, string password, Specialization specialization) : this(Guid.NewGuid(), userType, name, surname, email, password, specialization)
        { }
        public Doctor(Guid id, Usertype userType, string name, string surname, string email, string password, Specialization specialization)
        {
            Id = id;
            UserType = userType;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Specialization = specialization;
        }

    }
}
