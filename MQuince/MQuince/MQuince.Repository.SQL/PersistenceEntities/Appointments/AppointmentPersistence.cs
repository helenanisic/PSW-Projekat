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
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TreatmentType Type { get; set; }

        [ForeignKey("DoctorId")]
        public DoctorPersistence DoctorPersistence { get; set; }
        public Guid DoctorId { get; set; }

        [ForeignKey("PatientId")]
        public PatientPersistence PatientPersistence { get; set; }
        public Guid PatientId { get; set; }
    }
}
