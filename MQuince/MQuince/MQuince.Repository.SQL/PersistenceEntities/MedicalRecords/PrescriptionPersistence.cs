using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("reserved_medicine")]
    public class PrescriptionPersistence
    {
        [Key]
        public string uid { get; set; }
        public bool approved { get; set; }
        public DateTime date { get; set; }
        public string patient_name { get; set; }
        public int quantity { get; set; }
        public int medicine_id { get; set; }
        public int patient_id { get; set; }       
        public int pharmacy_id { get; set; }
    }
}
