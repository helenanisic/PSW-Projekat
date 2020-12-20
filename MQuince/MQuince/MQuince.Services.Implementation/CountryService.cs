using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.Services.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public Guid Create(CountryDTO entityDTO)
        {
            Country country = CreateCountryFromDTO(entityDTO);
            _countryRepository.Create(country);
            return country.Id;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<CountryDTO>> GetAll()
            => _countryRepository.GetAll().Select(c => CreateCountryDTO(c));

        public IdentifiableDTO<CountryDTO> GetById(Guid id)
            => CreateCountryDTO(_countryRepository.GetById(id));

            public void Update(CountryDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
        private IdentifiableDTO<CountryDTO> CreateCountryDTO(Country country)
            {
                if (country == null) return null;

                return new IdentifiableDTO<CountryDTO>()
                {
                    Id = country.Id,
                    EntityDTO = new CountryDTO()
                    {
                        Name = country.Name
                    }
                };
            }

        private Country CreateCountryFromDTO(CountryDTO country, Guid? id = null)
                => id == null ? new Country(country.Name)
                    : new Country(id.Value, country.Name);
    }
}
