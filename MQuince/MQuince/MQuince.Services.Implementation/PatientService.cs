using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<PatientDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IdentifiableDTO<PatientDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(PatientDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
