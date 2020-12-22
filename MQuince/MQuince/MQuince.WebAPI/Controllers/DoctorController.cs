using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController([FromServices] IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            _doctorService.Create(new DoctorDTO() {});
            return Ok();
        }
        
        [HttpGet("GetAll")]
        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetAll()
        {
            return _doctorService.GetAll();
        }
    }
}