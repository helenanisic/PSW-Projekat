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
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController([FromServices] ICityService cityService)
        {
            this._cityService = cityService;
        }


        [HttpGet]
        public IActionResult Create()
        {

            _cityService.Create(new CityDTO() { Name = "Beograd" });
            _cityService.Create(new CityDTO() { Name = "Novi Sad" });
            _cityService.Create(new CityDTO() { Name = "Segedin" });
            _cityService.Create(new CityDTO() { Name = "Budimpešta" });
            return Ok();
        }

    }
}