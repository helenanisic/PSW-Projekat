using MQuince.Entities.MedicalRecords;
using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class MedicalRecordDTO
    {
        public string Note { get; set; }
        public List<MedicalHistory> MedicalHistory { get; set; } = new List<MedicalHistory>();
        public List<RiskFactor> RiskFactor { get; set; } = new List<RiskFactor>();
        public List<FamilyRiskFactor> FamilyRiskFactor { get; set; } = new List<FamilyRiskFactor>();
        public List<RiskAllergies> RiskAllergies { get; set; } = new List<RiskAllergies>();
        public List<Immunization> Immunization { get; set; } = new List<Immunization>();
        public List<Treatment> Treatment { get; set; } = new List<Treatment>();

    }
}
