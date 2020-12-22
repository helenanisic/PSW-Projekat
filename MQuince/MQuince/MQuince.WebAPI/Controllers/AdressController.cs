using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAdressService _adressService;

        public AdressController([FromServices] IAdressService adressService)
        {
            this._adressService = adressService;
        }

        [HttpPost]
        public IActionResult Create(AdressDTO adress)
        {
            Guid id = _adressService.Create(adress);
            return Ok(id);
        }
    }
}