using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpFunctionalExtensions;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public Result<Guid> Create(Patient patient)
        {
            if (!IsEmailUnique(patient.Email))
                return Result.Failure<Guid>("Email nije jedinstven!");
            Guid _id = _patientRepository.Create(patient);
            if (_id == Guid.Empty)
                return Result.Failure<Guid>("Neuspesan upis u bazu!");
            return Result.Success(_id);
        }

        public IEnumerable<IdentifiableDTO<PatientDTO>> GetAll()
            => _patientRepository.GetAll().Select(c => CreatePatientDTO(c));


        private IdentifiableDTO<PatientDTO> CreatePatientDTO(Patient patient)
        {
            if (patient == null) return null;
            return new IdentifiableDTO<PatientDTO>()
            {
                Id = patient.Id,
                EntityDTO = new PatientDTO()
                {
                    UserType = Enums.Usertype.Patient,
                    Name = patient.Name,
                    Surname = patient.Surname,
                    Email = patient.Email,
                    Password = patient.Password,
                    ResidenceId = patient.ResidenceId,
                    BirthDate = patient.BirthDate,
                    Jmbg = patient.Jmbg,
                    Gender = patient.Gender,
                    Lbo = patient.Lbo,
                    Telephone = patient.Telephone,
                    ChosenDoctorId = patient.ChosenDoctorId

                }
            };
        }


        public bool IsEmailUnique(String email)
        {
            return _patientRepository.IsEmailUnique(email);
        }

        public IEnumerable<Patient> GetMaliciousPatients()
        {
            return _patientRepository.GetMaliciousPatients();
        }

        public Patient BanPatient(Guid id)
        {
            Patient patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                return null;
            }
            else
            {
                patient.Banned = true;
                return _patientRepository.BanPatient(patient);
            }
            
        }

        public Patient GetById(Guid id)
        {
            return _patientRepository.GetById(id);
        }
    }
}
