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
        public List<RiskFactor> RiskFactor { get; set; } = new List<RiskFactor>();
        public List<FamilyRiskFactor> FamilyRiskFactor { get; set; } = new List<FamilyRiskFactor>();
        public List<RiskAllergies> RiskAllergies { get; set; } = new List<RiskAllergies>();
        public List<Immunization> Immunization { get; set; } = new List<Immunization>();
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
