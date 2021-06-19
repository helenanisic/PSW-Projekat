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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public Guid Create(DoctorDTO entityDTO)
        {
            Doctor doctor = CreateDoctorFromDTO(entityDTO);

            _doctorRepository.Create(doctor);

            return doctor.Id;
        }

        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetAll()
            => _doctorRepository.GetAll().Select(c => CreateDoctorDTO(c));


        private IdentifiableDTO<DoctorDTO> CreateDoctorDTO(Doctor doctor)
        {
            if (doctor == null) return null;

            return new IdentifiableDTO<DoctorDTO>()
            {
                Id = doctor.Id,
                EntityDTO = new DoctorDTO()
                {
                    UserType = doctor.UserType,
                    Name = doctor.Name,
                    Surname = doctor.Surname,
                    Email = doctor.Email,
                    Password = doctor.Password,
                    SpecializationId = doctor.SpecializationId

                }
            };
        }

        private Doctor CreateDoctorFromDTO(DoctorDTO doctor, Guid? id = null)
            => id == null ? new Doctor(doctor.UserType, doctor.Name, doctor.Surname, doctor.Email, doctor.Password, doctor.SpecializationId)
                : new Doctor(id.Value, doctor.UserType, doctor.Name, doctor.Surname, doctor.Email, doctor.Password, doctor.SpecializationId);
    }
}
