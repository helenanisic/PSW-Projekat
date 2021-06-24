﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController([FromServices] IPatientService patientService)
        {
            this._patientService = patientService;
        }

        [HttpPost]
        public IActionResult Create(PatientDTO patient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Podaci nisu validni");
            var result = _patientService.Create(CreatePatientFromDTO(patient));
            if (result.IsFailure)
                return BadRequest("Email je zauzet");
            return Created("", result.Value);
        }

        [HttpGet("GetMaliciousPatient")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetMaliciousPatients()
        {
            IEnumerable<Patient> patients = _patientService.GetMaliciousPatients();
            IEnumerable<MaliciousPatientDTO> maliciousPatientDtos = patients.Select(p => CreateMaliciousPatientDTO(p));
            return Ok(maliciousPatientDtos);
        }

        public static Patient CreatePatientFromDTO(PatientDTO patient, Guid? id = null)
    => id == null ? new Patient(Enums.Usertype.Patient, patient.Name, patient.Surname, patient.Email, patient.Password, patient.Jmbg, patient.BirthDate, patient.Gender, patient.Telephone,
        patient.ResidenceId, patient.ChosenDoctorId, patient.Lbo, patient.MissedAppointments, patient.Banned)
                  : new Patient(id.Value, Enums.Usertype.Patient, patient.Name, patient.Surname, patient.Email, patient.Password, patient.Jmbg, patient.BirthDate, patient.Gender, patient.Telephone,
                      patient.ResidenceId, patient.ChosenDoctorId, patient.Lbo, patient
                      .MissedAppointments, patient.Banned);

        private MaliciousPatientDTO CreateMaliciousPatientDTO(Patient patient)
        {
            return new MaliciousPatientDTO()
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                MissedAppointments = patient.MissedAppointments,
                Banned = patient.Banned
            };
        }
    }
}