using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Specialization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Specialization()
        {
            Id = Guid.NewGuid();
        }

        public Specialization(string name) : this(Guid.NewGuid(), name) { }
        public Specialization(Guid id, string name)
        {
            Id = id;
            Name = name;
            
        }
    }
}
