using System;
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
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;

        public PatientController([FromServices] IPatientService patientService, IUserService userService, IDoctorService doctorService)
        {
            this._patientService = patientService;
            this._userService = userService;
            this._doctorService = doctorService;
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
            IEnumerable<PatientDTO> patientDTOs = patients.Select(p => CreatePatientDTO(p));
            return Ok(patients);
        }

        [HttpGet("BanPatient")]
        [Authorize(Roles = "Admin")]
        public IActionResult BanPatient(Guid id)
        {
            Patient patient = _patientService.BanPatient(id);
            if(patient == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(patient);
            }
        }

        [HttpGet("GetChosenDoctor")]
        [Authorize]
        public IActionResult GetChosenDoctor()
        {
            string token = Request.Headers["Authorization"];
            var id = _userService.GetIdFromJwtToken(token.Split(" ")[1]);
            Patient patient = _patientService.GetById(new Guid(id));
            Doctor doctor = _doctorService.GetById(patient.ChosenDoctorId);
            return Ok(doctor);
        }

        [HttpGet("GetAllNotBanned")]
        public IActionResult GetAllNotBanned()
        {
            IEnumerable<Patient> patients = _patientService.GetAllNotBanned();
            return Ok(patients);
        }

        public static Patient CreatePatientFromDTO(PatientDTO patient, Guid? id = null)
    => id == null ? new Patient(Enums.Usertype.Patient, patient.Name, patient.Surname, patient.Email, patient.Password, patient.Jmbg, patient.BirthDate, patient.Gender, patient.Telephone,
        patient.ResidenceId, patient.ChosenDoctorId, patient.Lbo, patient.MissedAppointments, patient.Banned)
                  : new Patient(id.Value, Enums.Usertype.Patient, patient.Name, patient.Surname, patient.Email, patient.Password, patient.Jmbg, patient.BirthDate, patient.Gender, patient.Telephone,
                      patient.ResidenceId, patient.ChosenDoctorId, patient.Lbo, patient
                      .MissedAppointments, patient.Banned);


        private PatientDTO CreatePatientDTO(Patient patient)
        {
            if (patient == null) return null;
            return new PatientDTO()
            {
                    Id = patient.Id,
                    UserType = Enums.Usertype.Patient,
                    Name = patient.Name,
                    Surname = patient.Surname,
                    Email = patient.Email,
                    Password = patient.Password,
                    ResidenceId = patient.ResidenceId,
                    BirthDate = patient.BirthDate,
                    Jmbg = patient.Jmbg,
                    Gender = patient.Gender,
                    Lbo = patient.Lbo,
                    Telephone = patient.Telephone,
                    ChosenDoctorId = patient.ChosenDoctorId,
                    MissedAppointments = patient.MissedAppointments,
                    Banned = patient.Banned
                
            };
        }

    }


}