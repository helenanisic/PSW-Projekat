using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Entities.Drug;
using MQuince.Entities.MedicalRecords;
using MQuince.Services.Contracts.DTO.MedicalRecords;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMedicineInPharmacyService _medicineInPharmacyService;

        public PrescriptionController([FromServices] IPrescriptionService prescriptionService, IMedicineInPharmacyService medicineInPharmacyService)
        {
            this._prescriptionService = prescriptionService;
            this._medicineInPharmacyService = medicineInPharmacyService;
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public IActionResult CreatePrescription(PrescriptionDTO prescriptionDTO)
        {           
            var result = _prescriptionService.Create(CreatePrescriptionFromDTO(prescriptionDTO));
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }

        private Prescription CreatePrescriptionFromDTO(PrescriptionDTO prescriptionDTO)
            => new Prescription(prescriptionDTO.Quantity,prescriptionDTO.MedicineId,prescriptionDTO.Patient.Name);
    }
}