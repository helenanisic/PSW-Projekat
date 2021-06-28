using MQuince.Entities.MedicalRecords;
using MQuince.Repository.SQL.PersistenceEntities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class PrescriptionMapper
    {
        public static Prescription MapPrescriptionPersistenceToPrescriptionEntity(PrescriptionPersistence prescription)
            => prescription == null ? null : new Prescription(prescription.uid, prescription.approved, prescription.date, prescription.quantity, prescription.medicine_id, prescription.patient_id, prescription.patient_name, prescription.pharmacy_id);

        public static IEnumerable<Prescription> MapReservedPrescriptionPersistenceCollectionToPrescriptionEntityCollection(IEnumerable<PrescriptionPersistence> prescriptions)
            => prescriptions.Select(c => MapPrescriptionPersistenceToPrescriptionEntity(c));

        public static PrescriptionPersistence MapPrescriptionEntityToPrescriptionPersistence(Prescription prescription)
        {
            if (prescription == null) return null;

            PrescriptionPersistence retVal = new PrescriptionPersistence()
            {
                uid = prescription.Id,
                date = prescription.Date,
                patient_name = prescription.PatientName,
                patient_id = prescription.PatientId,
                medicine_id = prescription.MedicineId,
                pharmacy_id = prescription.PharmacyId,
                quantity = prescription.Quantity,
                approved = prescription.IsApproved
            };
            return retVal;
        }

        public static IEnumerable<PrescriptionPersistence> MapPrescriptionEntityCollectionToPrescriptionPersistenceCollection(IEnumerable<Prescription> prescriptions)
        {
            return prescriptions.Select(c => MapPrescriptionEntityToPrescriptionPersistence(c));
        }
    }
}
