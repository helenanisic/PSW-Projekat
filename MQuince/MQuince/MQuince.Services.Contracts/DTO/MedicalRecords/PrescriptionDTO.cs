using MQuince.Entities.Drug;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class PrescriptionDTO
    {
        public PatientDTO Patient { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }

    }
}
