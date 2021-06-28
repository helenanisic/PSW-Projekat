using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MQuince.Entities.Drug;
using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class Prescription
    {
        public string Id { get; set; }
        public bool IsApproved { get; set; }
        public DateTime Date { get; set; }
        public string PatientName { get; set; }
        public int Quantity { get; set; }
        public int MedicineId { get; set; }
        public int PatientId { get; set; }       
        public int PharmacyId { get; set; }

        public Prescription()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Prescription(string id, bool isApproved, DateTime date, int quantity, int medicineId, int patientId, string patientName, int pharmacyId)
        {
            Id = id.ToString();
            IsApproved = isApproved;
            Date = date;
            Quantity = quantity;
            MedicineId = medicineId;
            PatientId = patientId;
            PatientName = patientName;
            PharmacyId = pharmacyId;

        }

        public Prescription(int quantity, int medicineId, string patientName) :
            this(Guid.NewGuid().ToString(), false, DateTime.Now.AddDays(14), quantity, medicineId, 999, patientName, 1)
        { }
        public Prescription(Guid id, int quantity, int medicineId, string patientName) :
            this(id.ToString(), false, DateTime.Now.AddDays(14), quantity, medicineId, 999, patientName, 1)
        { }
    }
}
