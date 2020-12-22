using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface ICityService : IService<CityDTO, IdentifiableDTO<CityDTO>>
    {
        public IEnumerable<IdentifiableDTO<CityDTO>> GetAllCitiesInCountry(Guid id);
    }
}
