using MQuince.Entities.Appointment;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Guid Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public IEnumerable<Appointment> GetAllAppointmentsByPatientId(Guid patientId)
        {
            return _appointmentRepository.GetAllAppointmentsByPatientId(patientId);
        }
    }
}
