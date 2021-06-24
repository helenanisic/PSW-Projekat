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
    }
}
