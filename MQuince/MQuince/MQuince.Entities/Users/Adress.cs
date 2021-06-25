using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Adress
    {
        public Guid Id;
        [Required]
        [RegularExpression("([0-9].+)")]
        public int Number { get; set; }
        public string Street { get; set; }
        public Guid CityId { get; set; }

        public Adress()
        {
            Id = Guid.NewGuid();
        }

        public Adress(int number, string street, Guid cityId) : this(Guid.NewGuid(), number, street, cityId) { }
        public Adress(Guid id, int number, string street, Guid cityId)
        {
            Id = id;
            Number = number;
            Street = street;
            CityId = cityId;
        }
    }
}
