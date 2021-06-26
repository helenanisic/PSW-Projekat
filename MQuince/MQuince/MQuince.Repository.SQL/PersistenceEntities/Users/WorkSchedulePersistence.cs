using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("WorkSchedule")]
    public class WorkSchedulePersistence
    {
        [Key]
        public Guid Id {get; set;}
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        [ForeignKey("DoctorId")]
        public DoctorPersistence Doctor { get; set; }
        public Guid DoctorId { get; set; }
    }
}
