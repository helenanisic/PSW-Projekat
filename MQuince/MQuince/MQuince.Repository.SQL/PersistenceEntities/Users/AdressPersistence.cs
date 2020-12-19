using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities
{
    [Table("Adress")]
    public class AdressPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public City City { get; set; }
    }
}
