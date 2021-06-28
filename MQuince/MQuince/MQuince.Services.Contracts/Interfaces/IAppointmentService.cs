using CSharpFunctionalExtensions;
using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Enums;
using MQuince.Services.Contracts.DTO.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointmentsByPatientId(Guid patientId);
        Guid Create(Appointment appointment);
        AppointmentDTO RecommendAppointment(DateTime startDate, DateTime endDate, int startTime, int endTime, Guid DoctorId, AppointmentPriority appointmentPriority, Guid specializationId);

        Result<bool> Delete(Guid id);
        Appointment GetById(Guid id);
    }
}
