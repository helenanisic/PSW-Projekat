using MQuince.Entities.Drug;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class MedicineMapper
    {
        public static Medicine MapMedicinePersistenceToMedicineEntity(MedicinePersistence medicine)
        {
            return medicine == null ? null : new Medicine(medicine.id, medicine.name);
        }

        public static IEnumerable<Medicine> MapMedicinePersistenceCollectionToMedicineEntityCollection(
            IEnumerable<MedicinePersistence> medicines)
        {
            return medicines.Select(c => MapMedicinePersistenceToMedicineEntity(c));
        }

        public static MedicinePersistence MapMedicineEntityToMedicinePersistence(Medicine medicine)
        {
            if (medicine == null) return null;

            var retVal = new MedicinePersistence()
            {
                id = medicine.Id,
                name = medicine.Name
            };
            return retVal;
        }

        public static IEnumerable<MedicinePersistence> MapMedicineEntityCollectionToMedicinePersistenceCollection(
            IEnumerable<Medicine> medicines)
        {
            return medicines.Select(c => MapMedicineEntityToMedicinePersistence(c));
        }
    }
}
