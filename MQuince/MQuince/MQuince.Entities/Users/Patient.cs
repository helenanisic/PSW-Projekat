using MQuince.Entities.MedicalRecords;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Patient : User
    {
        public string Jmbg { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Telephone { get; set; }
        public Adress Residence { get; set; }
        public Doctor ChosenDoctor { get; set; }
        public string Lbo { get; set; }

        public Patient()
        {
            Id = Guid.NewGuid();
        }

        public Patient(Usertype userType, string name, string surname, string email, string password, string jmbg, DateTime birthDate, Gender gender,
            string telephone, Adress residence, Doctor chosenDoctor, string lbo) : this(Guid.NewGuid(), userType, name, surname, email, password, jmbg, birthDate,gender,
            telephone, residence, chosenDoctor, lbo) { }
        public Patient(Guid id, Usertype userType, string name, string surname, string email, string password, string jmbg, DateTime birthDate, Gender gender,
            string telephone, Adress residence, Doctor chosenDoctor, string lbo)
        {
            Id = id;
            UserType = userType;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Jmbg = jmbg;
            BirthDate = birthDate;
            Gender = gender;
            Telephone = telephone;
            Residence = residence;
            ChosenDoctor = chosenDoctor;
            Lbo = lbo;
        }
    }
}
