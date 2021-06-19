using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface ICountryService
    {
        IdentifiableDTO<CountryDTO> GetById(Guid id);
        IEnumerable<IdentifiableDTO<CountryDTO>> GetAll();
        Guid Create(CountryDTO entityDTO);
    }
}
