﻿using MQuince.Entities;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IUserService : IService<UserDTO, IdentifiableDTO<UserDTO>>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        bool IsUserTypePatient(Guid id);
        bool IsUserTypeAdmin(Guid guid);
        string GetIdFromJwtToken(string token);
        string GetRoleFromJwtToken(string token);

        User GetById(Guid id);
    }
}
