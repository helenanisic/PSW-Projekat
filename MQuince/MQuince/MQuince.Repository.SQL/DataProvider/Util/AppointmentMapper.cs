﻿
using MQuince.Entities.Appointment;
using MQuince.Repository.SQL.PersistenceEntities.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class AppointmentMapper
    {
        public static Appointment MapAppointmentPersistenceToAppointmentEntity(AppointmentPersistence appointment)
        => appointment == null ? null : new Appointment(appointment.Id, appointment.Date, appointment.StartTime, appointment.Type, DoctorMapper.MapDoctorPersistenceToDoctorEntity(appointment.Doctor), PatientMapper.MapPatientPersistenceToPatientEntity(appointment.Patient), appointment.Status);

        public static IEnumerable<Appointment> MapAppointmentPersistenceCollectionToAppointmentEntityCollection(IEnumerable<AppointmentPersistence> appointments)
            => appointments.Select(c => MapAppointmentPersistenceToAppointmentEntity(c));

        public static IEnumerable<AppointmentPersistence> MapAppointmentEntityCollectionToAppointmentPersistenceCollection(IEnumerable<Appointment> appointments)
            => appointments.Select(c => MapAppointmentEntityToAppointmentPersistence(c));

        public static AppointmentPersistence MapAppointmentEntityToAppointmentPersistence(Appointment appointment)
        {
            if (appointment == null) return null;
            AppointmentPersistence retVal = new AppointmentPersistence()
            {
                Id = appointment.Id,
                Date = appointment.Date,
                StartTime = appointment.StartTime,
                Type = appointment.Type,
                DoctorId = appointment.Doctor.Id,
                PatientId = appointment.Patient.Id,
                Status = appointment.Status
            };

            return retVal;
        }
    }
}
