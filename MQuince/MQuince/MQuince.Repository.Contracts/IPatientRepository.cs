using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.Contracts
{
    public interface IPatientRepository
    {
        bool IsEmailUnique(string email);
        Guid Create(Patient entity);
        IEnumerable<Patient> GetAll();
        IEnumerable<Patient> GetMaliciousPatients();
    }
}
