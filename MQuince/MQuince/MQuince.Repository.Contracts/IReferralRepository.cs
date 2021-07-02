using MQuince.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IReferralRepository
    {
        IEnumerable<Referral> GetReferralOfPatient(Guid patientId, bool used);
        Referral Update(Referral entity);
    }
}
