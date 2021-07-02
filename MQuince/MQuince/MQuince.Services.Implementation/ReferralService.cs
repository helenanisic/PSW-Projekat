using MQuince.Entities.MedicalRecords;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Referral> GetReferralOfPatient(Guid patientId, bool used)
        {
            return _referralRepository.GetReferralOfPatient(patientId, used);
        }

        public bool ReferralUsage(Guid patientId, Guid specializationId, bool used)
        {
            IEnumerable<Referral> referrals = _referralRepository.GetReferralOfPatient(patientId, !used);

            foreach(Referral referral in referrals)
            {
                if (referral.Specialization.Id == specializationId)
                {
                    referral.Used = used;
                    var refer = _referralRepository.Update(referral);
                    return true;
                }
                    
            }
            return true;
            
        }
    }


}
