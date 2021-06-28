using MQuince.Entities.Drug;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public static class MedicineInPharmacyMapper
    {
        public static MedicineInPharmacy MapMedicineInPharmacyPersistenceToMedicineInPharmacyEntity(MedicineInPharmacyPersistence medicineInPharmacy)
           => medicineInPharmacy == null ? null : new MedicineInPharmacy(medicineInPharmacy.medicine_id, medicineInPharmacy.pharmacy_id, medicineInPharmacy.quantity);

        public static IEnumerable<MedicineInPharmacy> MapMedicineInPharmacyPersistenceCollectionToMedicineInPharmacyEntityCollection(IEnumerable<MedicineInPharmacyPersistence> medicineInPharmacies)
            => medicineInPharmacies.Select(c => MapMedicineInPharmacyPersistenceToMedicineInPharmacyEntity(c));

        public static MedicineInPharmacyPersistence MapMedicineInPharmacyEntityToMedicineInPharmacyPersistence(MedicineInPharmacy medicineInPharmacy)
        {
            if (medicineInPharmacy == null) return null;

            MedicineInPharmacyPersistence retVal = new MedicineInPharmacyPersistence()
            {
                medicine_id = medicineInPharmacy.MedicineId,
                pharmacy_id = medicineInPharmacy.PharmacyId,
                quantity = medicineInPharmacy.Quantity
            };
            return retVal;
        }
    }
}
