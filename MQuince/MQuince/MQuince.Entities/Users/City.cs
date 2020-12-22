using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class City
    {
        private Guid _id;
        public string Name { get; set; }
        public int PostNumber { get; set; }
        public Guid CountryId { get; set; }

        public Guid Id
        {
            get => _id;
            private set => _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
        }
        public City()
        {
            Id = Guid.NewGuid();
        }
        public City(string name, int postNumber, Guid countryId) : this(Guid.NewGuid(), name, postNumber, countryId) { }
        public City(Guid id, string name, int postNumber, Guid countryId)
        {
            _id = id;
            Name = name;
            PostNumber = postNumber;
            CountryId = countryId;
        }
    }
}
