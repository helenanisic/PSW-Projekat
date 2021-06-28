using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Drug
{
    [Table("medicine_in_pharmacy")]
    public class MedicineInPharmacyPersistence
    {
        public int quantity { get; set; }
        public int medicine_id { get; set; }
        public int pharmacy_id { get; set; }
    }
}
