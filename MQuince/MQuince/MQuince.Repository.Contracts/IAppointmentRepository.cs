using MQuince.Entities.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointmentsByPatientId(Guid patientId);
        Guid Create(Appointment appointment);
        IEnumerable<Appointment> GetBookedAppointmentsForDoctorInDateRange(DateTime startDate, DateTime endDate, Guid DoctorId);
        IEnumerable<Appointment> GetAppointmentsAnyDoctor(DateTime startDate, DateTime endDate);
    }
}
