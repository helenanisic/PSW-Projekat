using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Doctor")]
    public class DoctorPersistence : UserPersistence
    {
        public SpecializationPersistence Specialization { get; set; }
    }
}
