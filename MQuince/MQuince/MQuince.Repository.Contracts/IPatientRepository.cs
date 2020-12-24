using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.Contracts
{
    public interface IPatientRepository : IRepository<Patient>
    {
        bool CheckUniqueEmail(string email);
        bool AuthenticatePatient(UserLoginDTO user);
    }
}
