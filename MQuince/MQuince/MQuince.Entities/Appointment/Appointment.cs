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
        private Guid _id;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TreatmentType Type { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public Appointment()
        {
            this.Id = Guid.NewGuid();
        }

        public Appointment(Guid id, DateTime startDateTime, DateTime endDateTime, TreatmentType type, Doctor doctor, Patient patient)
        {
            Id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Type = type;
            Doctor = doctor;
            Patient = patient;
        }

        public Appointment(DateTime startDateTime, DateTime endDateTime, TreatmentType type, Doctor doctor, Patient patient) :
            this(Guid.NewGuid(), startDateTime, endDateTime, type, doctor, patient)
        {

        }

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

    }
}
