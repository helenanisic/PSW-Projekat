using MQuince.Entities.MedicalRecords;
using MQuince.Repository.SQL.PersistenceEntities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class ReferralMapper
    {
        public static Referral MapReferralPersistenceToReferralEntity(ReferralPersistence referral)
        {
            return referral == null ? null : new Referral(referral.Id,PatientMapper.MapPatientPersistenceToPatientEntity(referral.Patient),SpecializationMapper.MapSpecializationPersistenceToSpecializationEntity(referral.Specialization), referral.Used);
        }

        public static IEnumerable<Referral> MapReferralPersistenceCollectionToReferralEntityCollection(
            IEnumerable<ReferralPersistence> referrals)
        {
            return referrals.Select(c => MapReferralPersistenceToReferralEntity(c));
        }

        public static ReferralPersistence MapReferralEntityToReferralPersistence(Referral referral)
        {
            if (referral == null) return null;

            var retVal = new ReferralPersistence()
            {
                Id = referral.Id,
                SpecializationId = referral.Specialization.Id,
                PatientId = referral.Patient.Id,
                Used = referral.Used
            };
            return retVal;
        }

        public static IEnumerable<ReferralPersistence> MapReferralEntityCollectionToReferralPersistenceCollection(
            IEnumerable<Referral> referrals)
        {
            return referrals.Select(c => MapReferralEntityToReferralPersistence(c));
        }
    }
}
