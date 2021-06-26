using MQuince.Enums;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Appointments
{
    [Table("Appointment")]
    public class AppointmentPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public TreatmentType Type { get; set; }
        public AppointmentStatus Status { get; set; }

        [ForeignKey("DoctorId")]
        public DoctorPersistence Doctor { get; set; }
        public Guid DoctorId { get; set; }

        [ForeignKey("PatientId")]
        public PatientPersistence Patient { get; set; }
        public Guid PatientId { get; set; }
    }
}
