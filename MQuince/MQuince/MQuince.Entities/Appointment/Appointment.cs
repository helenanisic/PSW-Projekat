
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
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public TreatmentType Type { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public AppointmentStatus Status {get; set; }

        public Appointment()
        {
            this.Id = Guid.NewGuid();
        }

        public Appointment(Guid id, DateTime date, int startTime, TreatmentType type, Doctor doctor, Patient patient, AppointmentStatus status)
        {
            Id = id;
            Date = date;
            StartTime = startTime;
            Type = type;
            Doctor = doctor;
            Patient = patient;
            Status = status;
        }

        public Appointment(DateTime date, int startTime, TreatmentType type, Doctor doctor, Patient patient, AppointmentStatus status) :
            this(Guid.NewGuid(), date, startTime, type, doctor, patient, status)
        {

        }

    }
}
