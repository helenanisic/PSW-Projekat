using CSharpFunctionalExtensions;
using MQuince.Entities.Drug;
using MQuince.Entities.MedicalRecords;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMedicineInPharmacyRepository _medicineInPharmacyRepository;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMedicineInPharmacyRepository medicineInPharmacyRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _medicineInPharmacyRepository = medicineInPharmacyRepository;
        }

        public Result<string> Create(Prescription entity)
        {
            MedicineInPharmacy medicineInPharmacy = _medicineInPharmacyRepository.GetMedicineInPharmacy(entity.MedicineId);
            if (medicineInPharmacy == null)
                return Result.Failure<string>("Lek nije dostupan u apoteci!");
            if (medicineInPharmacy.Quantity < entity.Quantity)
                return Result.Failure<string>("Nema vise leka na zalihama!");

            String result = _prescriptionRepository.Create(entity);
            if (result == string.Empty)
                return Result.Failure<string>("Greska pri kreiranju!");
            return Result.Success(result);
        }

    }
}
