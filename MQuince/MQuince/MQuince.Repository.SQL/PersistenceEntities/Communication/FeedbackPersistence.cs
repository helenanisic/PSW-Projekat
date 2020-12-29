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
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Comment { get; set; }
        [ForeignKey("PatientId")]
        public PatientPersistence Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public bool Published { get; set; }
    }
}
