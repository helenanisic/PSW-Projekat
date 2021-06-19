using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;

namespace MQuince.Repository.Contracts
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAllCitiesInCountry(Guid id);
        City GetById(Guid id);
        IEnumerable<City> GetAll();
        Guid Create(City entity);
    }
}
