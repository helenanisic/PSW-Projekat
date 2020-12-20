using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Specialization
    {
        private Guid _id;
        public string Name { get; set; }

        public Guid Id
        {
            get => _id;
            protected set => _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;

        }
        public Specialization()
        {
            _id = Guid.NewGuid();
        }

        public Specialization(string name) : this(Guid.NewGuid(), name) { }
        public Specialization(Guid id, string name)
        {
            _id = id;
            Name = name;
            
        }
    }
}
