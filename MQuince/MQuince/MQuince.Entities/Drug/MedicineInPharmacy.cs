using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Drug
{
    public class MedicineInPharmacy
    {
        public int MedicineId { get; set; }
        public int PharmacyId { get; set; }
        public int Quantity { get; set; }

        public MedicineInPharmacy() { }
        public MedicineInPharmacy(int medicineId, int pharmacyId, int quantity)
        {
            MedicineId = medicineId;
            PharmacyId = pharmacyId;
            Quantity = quantity;
        }
    }
}
