using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Drug
{
    [Table("medicine")]
    public class MedicinePersistence
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
