using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface ICityService
    {
        public IEnumerable<IdentifiableDTO<CityDTO>> GetAllCitiesInCountry(Guid id);
        IdentifiableDTO<CityDTO> GetById(Guid id);
        IEnumerable<IdentifiableDTO<CityDTO>> GetAll(); 
        Guid Create(CityDTO entityDTO);
    }
}
