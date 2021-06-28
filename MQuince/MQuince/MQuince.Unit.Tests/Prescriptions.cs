using CSharpFunctionalExtensions;
using Moq;
using MQuince.Entities.Drug;
using MQuince.Entities.MedicalRecords;
using MQuince.Repository.Contracts;
using MQuince.Services.Implementation;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Unit.Tests
{
    public class Prescriptions
    {
        [Fact]
        public void medicine_prescription_success()
        {
            Prescription prescription = new Prescription(1, 123, "Milan");
            MedicineInPharmacy medicineInPharmacy = new MedicineInPharmacy(prescription.MedicineId, prescription.PharmacyId, 10);
            var stubRepository1 = new Mock<IPrescriptionRepository>();
            var stubRepository2 = new Mock<IMedicineInPharmacyRepository>();
            stubRepository1.Setup(p => p.Create(prescription)).Returns(prescription.Id);
            stubRepository2.Setup(p => p.GetMedicineInPharmacy(prescription.MedicineId)).Returns(medicineInPharmacy);
            PrescriptionService prescriptionService = new PrescriptionService(stubRepository1.Object, stubRepository2.Object);
            Result<string> result = prescriptionService.Create(prescription);
            result.ShouldBe(prescription.Id);
        }

        [Fact]
        public void medicine_prescription_quantity_fail()
        {
            Prescription prescription = new Prescription(3, 123, "Milan");
            MedicineInPharmacy medicineInPharmacy = new MedicineInPharmacy(prescription.MedicineId, prescription.PharmacyId, 1);
            var stubRepository1 = new Mock<IPrescriptionRepository>();
            var stubRepository2 = new Mock<IMedicineInPharmacyRepository>();
            stubRepository1.Setup(p => p.Create(prescription)).Returns(prescription.Id);
            stubRepository2.Setup(p => p.GetMedicineInPharmacy(prescription.MedicineId)).Returns(medicineInPharmacy);
            PrescriptionService prescriptionService = new PrescriptionService(stubRepository1.Object, stubRepository2.Object);
            Result<string> result = prescriptionService.Create(prescription);
            Result<string> resultBad = Result.Failure<string>("Nema vise leka na zalihama!");
            result.ShouldBe(resultBad);
        }

        [Fact]
        public void medicine_prescription_not_in_pharmacy_fail()
        {
            Prescription prescription = new Prescription(3, 123, "Milan");
            MedicineInPharmacy medicineInPharmacy = new MedicineInPharmacy(prescription.MedicineId, prescription.PharmacyId, 1);
            var stubRepository1 = new Mock<IPrescriptionRepository>();
            var stubRepository2 = new Mock<IMedicineInPharmacyRepository>();
            stubRepository1.Setup(p => p.Create(prescription)).Returns(prescription.Id);
            stubRepository2.Setup(p => p.GetMedicineInPharmacy(prescription.MedicineId));
            PrescriptionService prescriptionService = new PrescriptionService(stubRepository1.Object, stubRepository2.Object);
            Result<string> result = prescriptionService.Create(prescription);
            Result<string> resultBad = Result.Failure<string>("Lek nije dostupan u apoteci!");
            result.ShouldBe(resultBad);
        }
    }
}
