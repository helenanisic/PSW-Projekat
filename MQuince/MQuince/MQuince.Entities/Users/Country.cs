using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Country
    {
        private Guid _id;
        public string Name { get; set; }

        public Guid Id
        {
            get => _id;
            private set => _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
        }
        public Country()
        {
            Id = Guid.NewGuid();
        }
        public Country(string name) : this(Guid.NewGuid(), name) { }
        public Country(Guid id, string name)
        {
            _id = id;
            Name = name;
        }


    }
}
