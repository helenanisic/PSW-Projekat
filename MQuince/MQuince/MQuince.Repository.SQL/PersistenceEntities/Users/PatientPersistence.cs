﻿using MQuince.Entities.MedicalRecords;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Patient")]
    public class PatientPersistence : UserPersistence
    { 
        public string Jmbg { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Telephone { get; set; }
        public AdressDTO Residence { get; set; }
        public DoctorDTO ChosenDoctor { get; set; }
        public string Lbo { get; set; }
    }
}