using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.Services.Implementation
{
    public class AdressService : IAdressService
    {
        private readonly IAdressRepository _adressRepository;
        public AdressService(IAdressRepository adressRepository)
        {
            _adressRepository = adressRepository;
        }
        
        public Guid Create(AdressDTO entityDTO)
        {
            Adress adress = CreateAdressFromDTO(entityDTO);
            _adressRepository.Create(adress);
            return adress.Id;
        }

        private IdentifiableDTO<AdressDTO> CreateAdressDTO(Adress adress)
        {
            if (adress == null) return null;

            return new IdentifiableDTO<AdressDTO>()
            {
                Id = adress.Id,
                EntityDTO = new AdressDTO()
                {
                    Street = adress.Street,
                    Number = adress.Number,
                    CityId = adress.CityId
                }
            };
        }

        private Adress CreateAdressFromDTO(AdressDTO adress, Guid? id = null)
            => id == null ? new Adress(adress.Number, adress.Street, adress.CityId)
                : new Adress(id.Value, adress.Number, adress.Street,  adress.CityId);
    }
}
