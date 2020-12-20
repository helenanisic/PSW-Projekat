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
        public Country Country { get; set; }

        public Guid Id
        {
            get => _id;
            private set => _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
        }
        public City()
        {
            Id = Guid.NewGuid();
        }
        public City(string name, int postNumber, Country country) : this(Guid.NewGuid(), name, postNumber, country) { }
        public City(Guid id, string name, int postNumber, Country country)
        {
            _id = id;
            Name = name;
            PostNumber = postNumber;
            Country = country;
        }
    }
}
