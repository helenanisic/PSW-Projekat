using MQuince.Entities.MedicalRecords;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class PatientDTO : UserDTO
    {
        public string Jmbg { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Telephone { get; set; }
        public Adress Residence { get; set; }
        public Doctor ChosenDoctor { get; set; }
        public string Lbo { get; set; }
    }
}
