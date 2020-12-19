using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("RiskFactor")]
    public class RiskFactorPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string riskFactor { get; set; }
    }
}
