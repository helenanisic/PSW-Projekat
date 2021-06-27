using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<IdentifiableDTO<DoctorDTO>> GetAll();
        Guid Create(DoctorDTO entityDTO);
        IEnumerable<Doctor> GetDoctorBySpecialization(Guid specializationId);
        Doctor GetById(Guid id);
    }
}
