using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;

namespace MQuince.Repository.Contracts
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        Guid Create(Doctor entity);
        IEnumerable<Doctor> GetDoctorBySpecialization(Guid specializationId);

        Doctor GetById(Guid id);
    }
}
