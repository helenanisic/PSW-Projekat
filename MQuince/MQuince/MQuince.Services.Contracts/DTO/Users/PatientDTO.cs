using MQuince.Entities.MedicalRecords;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MQuince.Entities.Users;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class PatientDTO : UserDTO
    {
        [Required]
        [RegularExpression("([0-9].{12,12})")]
        public string Jmbg { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [RegularExpression("([0-9].+)")]
        public string Telephone { get; set; }
        public Guid ResidenceId { get; set; }
        public Guid ChosenDoctorId { get; set; }
        [RegularExpression("([0-9].+)")]
        public string Lbo { get; set; }

        public int MissedAppointments { get; set; }
        public bool Banned { get; set; }
    }
}
