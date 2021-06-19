using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;

namespace MQuince.Repository.SQL.DataProvider
{
    public class AdressRepository : IAdressRepository
    {
        private readonly DbContextOptions _dbContext;

        public AdressRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        
        public Guid Create(Adress entity)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            context.Adresses.Add(AdressMapper.MapAdressEntityToAdressPersistence(entity));
            return context.SaveChanges() > 0 ? entity.Id : Guid.Empty;
        }

    }
}
