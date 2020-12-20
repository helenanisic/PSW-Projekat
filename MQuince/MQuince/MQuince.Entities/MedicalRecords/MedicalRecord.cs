using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class MedicalRecord
    {
        private Guid _id;
        public string Note { get; set; }
        public List<MedicalHistory> MedicalHistory { get; set; } = new List<MedicalHistory>();
        public List<Treatment> Treatment { get; set; } = new List<Treatment>();

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
