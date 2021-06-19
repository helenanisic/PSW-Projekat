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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DbContextOptions _dbContext;

        public DoctorRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public Guid Create(Doctor entity)
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            _context.Doctors.Add(DoctorMapper.MapDoctorEntityToDoctorPersistence(entity));
            return _context.SaveChanges() > 0 ? entity.Id : Guid.Empty;
        }

        public IEnumerable<Doctor> GetAll()
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return DoctorMapper.MapDoctorPersistenceCollectionToDoctorEntityCollection(_context.Doctors.ToList());
        }

    }
}
