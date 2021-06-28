using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Drug
{
    public class Medicine
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Medicine()
        {
            Id = new Int32();
        }
        public Medicine(string name) : this(new Int32(), name) { }
        public Medicine(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
