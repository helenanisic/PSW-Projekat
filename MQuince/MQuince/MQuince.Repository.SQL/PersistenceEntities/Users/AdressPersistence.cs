﻿using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MQuince.Repository.SQL.PersistenceEntities.Users;

namespace MQuince.Repository.SQL.PersistenceEntities
{
    [Table("Adress")]
    public class AdressPersistence
    { 
        [Key]
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        [ForeignKey("CityId")]
        public CityPersistence City { get; set; }
        public Guid CityId { get; set; }
    }
}
