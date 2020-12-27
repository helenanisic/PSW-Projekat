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
    public class CityRepository : ICityRepository
    {
        private readonly DbContextOptions _dbContext;

        public CityRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(City entity)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            context.Cities.Add(CityMapper.MapCityEntityToCityPersistence(entity));
            context.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return CityMapper.MapCityPersistenceCollectionToCityEntityCollection(context.Cities.ToList());
        }

        public City GetById(Guid id)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return CityMapper.MapCityPersistenceToCityEntity(context.Cities.SingleOrDefault(c => c.Id.Equals(id)));
        }

        public void Update(City entity)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAllCitiesInCountry(Guid id)
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return CityMapper.MapCityPersistenceCollectionToCityEntityCollection(_context.Cities.Where(p => p.Country.Id == id).ToList());
        }
    }
}
