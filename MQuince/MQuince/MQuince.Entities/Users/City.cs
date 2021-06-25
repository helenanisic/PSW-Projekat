using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Entities.Users
{
    public class City
    {
        public Guid Id;
        public string Name { get; set; }
        
        [RegularExpression("([0-9].{13})")]
        public int PostNumber { get; set; }
        public Guid CountryId { get; set; }

        public City()
        {
            Id = Guid.NewGuid();
        }
        public City(string name, int postNumber, Guid countryId) : this(Guid.NewGuid(), name, postNumber, countryId) { }
        public City(Guid id, string name, int postNumber, Guid countryId)
        {
            Id = id;
            Name = name;
            PostNumber = postNumber;
            CountryId = countryId;
        }
    }
}
