using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities.Users;

namespace MQuince.Repository.Contracts
{
    public interface ICountryRepository
    {
        Country GetById(Guid id);
        IEnumerable<Country> GetAll();
        Guid Create(Country entity);
    }
}
