using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MQuince.Repository.SQL.PersistenceEntities.Users;

namespace MQuince.Repository.SQL.PersistenceEntities
{
    [Table("Feedback")]
    public class FeedbackPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Comment { get; set; }
        [ForeignKey("PatientId")]
        public PatientPersistence Patient { get; set; }
        public Guid PatientId { get; set; }
        public bool Published { get; set; }
    }
}
