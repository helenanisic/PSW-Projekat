using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.Contracts
{
    public interface IUserRepository
    {
        User AuthenticateUser(AuthenticateRequest user);

        User GetById(Guid id); 
    }
}
