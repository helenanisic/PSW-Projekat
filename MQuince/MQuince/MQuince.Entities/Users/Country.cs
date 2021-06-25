using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
            Id = Guid.NewGuid();
        }
        public Country(string name) : this(Guid.NewGuid(), name) { }
        public Country(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


    }
}
