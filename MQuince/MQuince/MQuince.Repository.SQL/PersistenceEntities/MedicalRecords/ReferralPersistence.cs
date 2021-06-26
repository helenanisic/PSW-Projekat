using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("Referral")]
    public class ReferralPersistence
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("PatientId")]
        public PatientPersistence Patient { get; set; }
        public Guid PatientId { get; set; }

        [ForeignKey("SpecializationId")]
        public SpecializationPersistence Specialization { get; set; }
        public Guid SpecializationId { get; set; }
        public bool Used { get; set; }
    }
}
