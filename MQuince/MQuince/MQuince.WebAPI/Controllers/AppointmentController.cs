﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Application;
using MQuince.Entities.Appointment;
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

        public AppointmentController([FromServices] IAppointmentService appointmentService, IUserService userService)
        {
            this._appointmentService = appointmentService;
            this._userService = userService;
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
            AppointmentDTO works = _appointmentService.RecommendAppointment(request.StartDate, request.EndDate, request.StartTime, request.EndTime, request.DoctorId, request.appointmentPriority, request.SpecializationId);
            return Ok(works);
        }



        private AppointmentDTO CreateAppointmentDTO(Appointment appointment)
        {
            return new AppointmentDTO()
            {
                Date = appointment.Date,
                StartTime = appointment.StartTime,
                Type = appointment.Type.ToString(),
                DoctorName = appointment.Doctor.Name,
                DoctorSurname = appointment.Doctor.Surname,
                Status = appointment.Status.ToString()
            };
        }
    }
}