using MQuince.Entities.Drug;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IMedicineInPharmacyService
    {
        MedicineInPharmacy GetMedicineInPharmacy(int medicineId);
    }
}
