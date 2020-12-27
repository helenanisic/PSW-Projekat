using MQuince.Entities.MedicalRecords;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Patient : User
    {
        [Required]
        [RegularExpression("(^[0-9].{12,12}$)")]
        public string Jmbg { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [RegularExpression("([0-9].+)")]
        public string Telephone { get; set; }
        [Required]
        public Guid ResidenceId { get; set; }
        [Required]
        public Guid ChosenDoctorId { get; set; }
        [Required]
        [RegularExpression("([0-9].+)")]
        public string Lbo { get; set; }

        public Patient()
        {
            Id = Guid.NewGuid();
        }

        public Patient(Usertype userType, string name, string surname, string email, string password, string jmbg, DateTime birthDate, Gender gender,
            string telephone, Guid residenceId, Guid chosenDoctorId, string lbo) : this(Guid.NewGuid(), userType, name, surname, email, password, jmbg, birthDate,gender,
            telephone, residenceId, chosenDoctorId, lbo) { }
        public Patient(Guid id, Usertype userType, string name, string surname, string email, string password, string jmbg, DateTime birthDate, Gender gender,
            string telephone, Guid residenceId, Guid chosenDoctorId, string lbo)
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
            ResidenceId = residenceId;
            ChosenDoctorId = chosenDoctorId;
            Lbo = lbo;
        }
    }
}
