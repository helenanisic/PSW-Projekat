﻿using System;
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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public Guid Create(CityDTO entityDTO)
        {
            City city = CreateCityFromDTO(entityDTO);
            _cityRepository.Create(city);
            return city.Id;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<CityDTO>> GetAll()
            => _cityRepository.GetAll().Select(c => CreateCityDTO(c));

        public IdentifiableDTO<CityDTO> GetById(Guid id)
            => CreateCityDTO(_cityRepository.GetById(id));

        public void Update(CityDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
        private IdentifiableDTO<CityDTO> CreateCityDTO(City city)
        {
            if (city == null) return null;

            return new IdentifiableDTO<CityDTO>()
            {
                Id = city.Id,
                EntityDTO = new CityDTO()
                {
                    Name = city.Name,
                    PostNumber = city.PostNumber,
                    Country = city.Country
                }
            };
        }

        private City CreateCityFromDTO(CityDTO city, Guid? id = null)
            => id == null ? new City(city.Name, city.PostNumber, city.Country)
                : new City(id.Value, city.Name, city.PostNumber, city.Country);
    }
}