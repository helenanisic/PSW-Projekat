using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Entities.Users;
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
            _doctorService.Create(new DoctorDTO() {
                UserType = Enums.Usertype.Doctor,
                Name = "Marko",
                Surname = "Maric",
                Email = "marko@gmail.com",
                Password = "Marko123",
                SpecializationId = new Guid("75910c98-913d-43d9-a012-ad8fa3cc4045")
            });
            return Ok();
        }
        
        [HttpGet("GetAll")]
        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetAll()
        {
            return _doctorService.GetAll();
        }

        [HttpGet("GetAllGenerals")]
        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetAllGenerals()
        {
            return _doctorService.GetAllGenerals();
        }

        [HttpGet("GetDoctorBySpecialization")]
        public IActionResult GetDoctorBySpecialization(Guid id)
        {
            IEnumerable<Doctor> doctors = _doctorService.GetDoctorBySpecialization(id);
            return Ok(doctors);
        }
    }
}