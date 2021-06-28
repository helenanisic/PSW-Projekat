using MQuince.Entities.Drug;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class MedicineInPharmacyService : IMedicineInPharmacyService
    {
        private readonly IMedicineInPharmacyRepository _medicineInPharmacyRepository;
        public MedicineInPharmacyService(IMedicineInPharmacyRepository medicineInPharmacyRepository)
        {
            _medicineInPharmacyRepository = medicineInPharmacyRepository;
        }
        public MedicineInPharmacy GetMedicineInPharmacy(int medicineId)
        {
            return _medicineInPharmacyRepository.GetMedicineInPharmacy(medicineId);
        }
    }
}
