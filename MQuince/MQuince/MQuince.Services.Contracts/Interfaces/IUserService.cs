﻿using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IUserService : IService<UserDTO, IdentifiableDTO<UserDTO>>
    {

    }
}