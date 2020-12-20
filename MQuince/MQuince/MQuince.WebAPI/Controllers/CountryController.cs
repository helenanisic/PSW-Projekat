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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController([FromServices] ICountryService countryService)
        {
            this._countryService = countryService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            _countryService.Create(new CountryDTO() { Name = "Srbija"});
            _countryService.Create(new CountryDTO() { Name = "Mađarska"});
            return Ok();
        }

        [HttpGet("GetAll")]
        public IEnumerable<IdentifiableDTO<CountryDTO>> GetAll()
        {
            return _countryService.GetAll();
        }
    }
}