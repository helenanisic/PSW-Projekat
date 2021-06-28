using MQuince.Entities.Drug;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IMedicineInPharmacyRepository
    {
        MedicineInPharmacy GetMedicineInPharmacy(int medicineId);
    }
}
