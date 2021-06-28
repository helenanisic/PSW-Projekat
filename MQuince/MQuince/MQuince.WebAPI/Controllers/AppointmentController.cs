using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Application;
using MQuince.Entities.Appointment;
using MQuince.Entities.MedicalRecords;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        private readonly IReferralService _referralService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public AppointmentController([FromServices] IAppointmentService appointmentService, IUserService userService, IReferralService referralService, IDoctorService doctorService, IPatientService patientService)
        {
            this._appointmentService = appointmentService;
            this._userService = userService;
            this._referralService = referralService;
            this._doctorService = doctorService;
            this._patientService = patientService;
        }

        [HttpGet("GetAppointmentsForPatient")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetAppointmentsForPatient()
        {
            string token = Request.Headers["Authorization"];
            var id = _userService.GetIdFromJwtToken(token.Split(" ")[1]);
            IEnumerable<Appointment> appointments = _appointmentService.GetAllAppointmentsByPatientId(new Guid(id));
            IEnumerable<AppointmentDTO> appointmentDTOs = appointments.Select(item => CreateAppointmentDTO(item));
            return Ok(appointmentDTOs);
        }

        [HttpPost("Recommend")]
        public IActionResult Recommend(AppointmentRequestDTO request)
        {

            DateTime startDate = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day);
            DateTime endDate = new DateTime(request.EndDate.Year, request.EndDate.Month, request.EndDate.Day);
            DateTime today = DateTime.Now;
            if(startDate< today || startDate > endDate)
            {
                return BadRequest("Please enter correct dates!");
            }
            if(request.StartTime >= request.EndTime)
            {
                return BadRequest("Please enter correct time");
            }
            AppointmentDTO works = _appointmentService.RecommendAppointment(startDate, endDate, (int)request.StartTime, (int)request.EndTime, request.DoctorId, request.AppointmentPriority, request.SpecializationId);
            if(works == null)
            {
                return BadRequest("We can't recommend you any appointment.");
            }
            Doctor doctor = _doctorService.GetById(works.DoctorId);
            works.DoctorName = doctor.Name;
            works.DoctorSurname = doctor.Surname;
            return Ok(works);
        }

        [HttpGet("GetReferrals")]
        public IActionResult GetReferrals()
        {
            string token = Request.Headers["Authorization"];
            var id = _userService.GetIdFromJwtToken(token.Split(" ")[1]);
            IEnumerable<Referral> referrals = _referralService.GetReferralOfPatient(new Guid(id));
            return Ok(referrals);
        }

        [HttpPost("Create")]
        [Authorize]
        public IActionResult CreateAppointment(AppointmentDTO appointmentDTO)
        {
            string token = Request.Headers["Authorization"];
            var id = _userService.GetIdFromJwtToken(token.Split(" ")[1]);
            Patient patient = _patientService.GetById(new Guid(id));
            Doctor doctor = _doctorService.GetById(appointmentDTO.DoctorId);
            Guid result = _appointmentService.Create(CreateAppointmentFromDTO(appointmentDTO, doctor, patient));
            if(result == Guid.Empty)
            {
                return BadRequest("Something went wrong, please try again!");
            }
            return Ok();
        }

        [HttpGet("Cancel")]
        [Authorize]
        public IActionResult DeleteAppointment(Guid id)
        {
            var result = _appointmentService.Delete(id);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok();
        }
        private AppointmentDTO CreateAppointmentDTO(Appointment appointment)
        {
            return new AppointmentDTO()
            {
                id = appointment.Id,
                Date = appointment.Date,
                StartTime = appointment.StartTime,
                Type = appointment.Type.ToString(),
                DoctorName = appointment.Doctor.Name,
                DoctorSurname = appointment.Doctor.Surname,
                Status = appointment.Status.ToString()
            };
        }

        private Appointment CreateAppointmentFromDTO(AppointmentDTO appointmentDTO, Doctor doctor, Patient patient)
            => new Appointment(appointmentDTO.Date, appointmentDTO.StartTime, Enums.TreatmentType.Examination, doctor,patient, Enums.AppointmentStatus.Pending);
    }
}