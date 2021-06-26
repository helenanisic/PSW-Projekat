using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class Referral
    {
        public Guid Id { get; set; }
        public Patient Patient { get; set; }
        public Specialization Specialization { get; set; }
        public bool Used { get; set; }

        public Referral()
        {
            Id = Guid.NewGuid();
        }

        public Referral(Patient patient, Specialization specialization, bool used) : this(Guid.NewGuid(), patient, specialization, used) { }
        public Referral(Guid id, Patient patient, Specialization specialization, bool used)
        {
            Id = id;
            Patient = patient;
            Specialization = specialization;
            Used = used;

        }
    }
}
