using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class CityDTO
    {
        public string Name { get; set; }
        public int PostNumber { get; set; }
        public Country Country { get; set; }
    }
}
