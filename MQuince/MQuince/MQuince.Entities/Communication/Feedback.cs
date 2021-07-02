using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MQuince.Entities
{
    public class Feedback
    {
        private Guid _id;
        public string Comment { get; set; }
        public Guid PatientId { get; set; }
        public bool Published { get; set; }

        public Feedback() { }

        public Feedback(Guid id, string comment, Guid patientId, bool published)
        {
            Id = id;
            Comment = comment;
            PatientId = patientId;
            Published = published;
        }

        public Feedback(string comment, Guid patientId, bool published)
            : this(Guid.NewGuid(), comment, patientId, published)
        {
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
