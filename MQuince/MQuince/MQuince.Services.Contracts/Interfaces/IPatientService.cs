using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IPatientService
    {
        bool IsEmailUnique(string email);

        Result<Guid> Create(Patient patient);
        IEnumerable<IdentifiableDTO<PatientDTO>> GetAll();
        IEnumerable<Patient> GetMaliciousPatients();
        Patient BanPatient(Guid id);
        Patient GetById(Guid id);
        IEnumerable<Patient> GetAllNotBanned();
    }
}
