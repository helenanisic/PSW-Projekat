using MQuince.Entities.MedicalRecords;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class ReferralService : IReferralService
    {
        private readonly IReferralRepository _referralRepository;
        public ReferralService(IReferralRepository referralRepository)
        {
            _referralRepository = referralRepository;
        }

        public IEnumerable<Referral> GetReferralOfPatient(Guid patientId)
        {
            return _referralRepository.GetReferralOfPatient(patientId);
        }
    }


}
