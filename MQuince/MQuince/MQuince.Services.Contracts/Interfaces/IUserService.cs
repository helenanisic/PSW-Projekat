﻿using MQuince.Entities;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        string GetIdFromJwtToken(string token);
        string GetRoleFromJwtToken(string token);

        User GetById(Guid id);
    }
}
