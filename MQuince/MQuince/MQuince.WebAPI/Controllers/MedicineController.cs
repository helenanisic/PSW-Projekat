using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Entities.Drug;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController([FromServices] IMedicineService medicineService)
        {
            this._medicineService = medicineService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Medicine> medicines = _medicineService.GetAll();
            return Ok(medicines);
        }
    }
}