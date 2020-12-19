using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class RiskFactor
    {
        private Guid _id;
        public string riskFactor { get; set; }

        public RiskFactor() { }

        public RiskFactor(Guid id, string rFactor)
        {
            Id = id;
            riskFactor = rFactor;
        }

        public RiskFactor(string rFactor)
            : this(Guid.NewGuid(), rFactor)
        {
        }

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
