using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;

namespace MQuince.Repository.SQL.DataProvider
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DbContextOptions _dbContext;

        public CountryRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public Guid Create(Country entity)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            context.Countries.Add(CountryMapper.MapCountryEntityToCountryPersistence(entity));
            return context.SaveChanges() > 0 ? entity.Id : Guid.Empty;
        }
        public IEnumerable<Country> GetAll()
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return CountryMapper.MapCountryPersistenceCollectionToCountryEntityCollection(context.Countries.ToList());
        }
        public Country GetById(Guid id)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return CountryMapper.MapCountryPersistenceToCountryEntity(context.Countries.SingleOrDefault(c => c.Id.Equals(id)));
        }
        public bool Update(Country entity)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
