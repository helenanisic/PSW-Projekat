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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public Guid Create(PatientDTO entityDTO)
        {
            Patient patient = CreatePatientFromDTO(entityDTO);

            _patientRepository.Create(patient);

            return patient.Id;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<PatientDTO>> GetAll()
            => _patientRepository.GetAll().Select(c => CreatePatientDTO(c));

        public IdentifiableDTO<PatientDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(PatientDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }

        private IdentifiableDTO<PatientDTO> CreatePatientDTO(Patient patient)
        {
            if (patient == null) return null;

            return new IdentifiableDTO<PatientDTO>()
            {
                Id = patient.Id,
                EntityDTO = new PatientDTO()
                {
                    UserType = patient.UserType,
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

        private Patient CreatePatientFromDTO(PatientDTO patient, Guid? id = null)
            => id == null ? new Patient(patient.UserType, patient.Name, patient.Surname, patient.Email, patient.Password, patient.Jmbg, patient.BirthDate, patient.Gender, patient.Telephone,
                patient.ResidenceId, patient.ChosenDoctorId,patient.Lbo)
                          : new Patient(id.Value, patient.UserType, patient.Name, patient.Surname, patient.Email, patient.Password, patient.Jmbg, patient.BirthDate, patient.Gender, patient.Telephone,
                              patient.ResidenceId, patient.ChosenDoctorId, patient.Lbo);

        public bool CheckUniqueEmail(String email)
        {
            return _patientRepository.CheckUniqueEmail(email);
        }

    }
}
