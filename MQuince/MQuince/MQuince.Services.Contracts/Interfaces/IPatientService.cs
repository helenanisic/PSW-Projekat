using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IPatientService : IService<PatientDTO, IdentifiableDTO<PatientDTO>>
    {
    }
}
