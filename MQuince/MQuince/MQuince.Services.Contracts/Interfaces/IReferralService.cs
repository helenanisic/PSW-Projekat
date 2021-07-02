using MQuince.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IReferralService
    {
        IEnumerable<Referral> GetReferralOfPatient(Guid patientId, bool used);
        bool ReferralUsage(Guid patientId, Guid specializationId, bool used);
    }
}
