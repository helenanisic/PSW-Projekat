using MQuince.Entities.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointmentsByPatientId(Guid patientId);
        Guid Create(Appointment appointment);
    }
}
