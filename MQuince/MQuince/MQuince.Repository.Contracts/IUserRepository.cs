using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User AuthenticateUser(AuthenticateRequest user);
        bool IsUserTypePatient(Guid id);
        bool IsUserTypeAdmin(Guid id);

        User GetById(Guid id); 
    }
}
