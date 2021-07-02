using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Doctor : User
    {
        public Guid SpecializationId { get; set; }

        public Doctor()
        {
            Id = Guid.NewGuid();
        }

        public Doctor(Usertype userType, string name, string surname, string email, string password, Guid specializationId) : this(Guid.NewGuid(), userType, name, surname, email, password, specializationId)
        { }
        public Doctor(Guid id, Usertype userType, string name, string surname, string email, string password, Guid specializationId)
        {
            Id = id;
            UserType = userType;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            SpecializationId = specializationId;
        }

    }
}
