using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO.Users;
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
            if (_patientService.CheckUniqueEmail(patient.Email) == false)
            {
                _patientService.Create(patient);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult AuthenticatePatient(string Email, string Password)
        {
            UserLoginDTO user = new UserLoginDTO() {Email = Email, Password = Password};
            bool authenticatedUser = _patientService.AuthenticatePatient(user);
            if (authenticatedUser == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}