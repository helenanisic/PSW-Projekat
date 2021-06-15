using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Guid AuthenticateUser(UserLoginDTO user);
        bool IsUserTypePatient(Guid id);
        bool IsUserTypeAdmin(Guid id);
    }
}
