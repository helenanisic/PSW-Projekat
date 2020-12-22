using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Adress
    {
        private Guid _id;
        public int Number { get; set; }
        public string Street { get; set; }
        public Guid CityId { get; set; }

        public Guid Id
        {
            get => _id;
            protected set => _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;

        }
        public Adress()
        {
            _id = Guid.NewGuid();
        }

        public Adress(int number, string street, Guid cityId) : this(Guid.NewGuid(), number, street, cityId) { }
        public Adress(Guid id, int number, string street, Guid cityId)
        {
            _id = id;
            Number = number;
            Street = street;
            CityId = cityId;
        }
    }
}
