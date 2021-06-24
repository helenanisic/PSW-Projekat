using MQuince.Entities.MedicalRecords;
using MQuince.Entities.Rooms;
using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Appointment
{

    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TreatmentType Type { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public AppointmentStatus Status {get; set; }

        public Appointment()
        {
            this.Id = Guid.NewGuid();
        }

        public Appointment(Guid id, DateTime startDateTime, DateTime endDateTime, TreatmentType type, Doctor doctor, Patient patient, AppointmentStatus status)
        {
            Id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Type = type;
            Doctor = doctor;
            Patient = patient;
            Status = status;
        }

        public Appointment(DateTime startDateTime, DateTime endDateTime, TreatmentType type, Doctor doctor, Patient patient, AppointmentStatus status) :
            this(Guid.NewGuid(), startDateTime, endDateTime, type, doctor, patient, status)
        {

        }

    }
}
