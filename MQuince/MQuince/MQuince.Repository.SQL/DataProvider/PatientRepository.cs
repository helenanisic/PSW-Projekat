
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.SQL.DataProvider
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DbContextOptions _dbContext;

        public PatientRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        
        public void Create(Patient entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Patients.Add(PatientMapper.MapPatientEntityToPatientPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return PatientMapper.MapPatientPersistenceCollectionToPatientEntityCollection(_context.Patients.ToList());
            }
        }

        public Patient GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }
        public bool CheckUniqueEmail(String email)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            Patient p = PatientMapper.MapPatientPersistenceToPatientEntity(context.Patients.SingleOrDefault(p => p.Email.Equals(email)));
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AuthenticatePatient(UserLoginDTO user)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            Patient p = PatientMapper.MapPatientPersistenceToPatientEntity(context.Patients.SingleOrDefault(p => p.Email.Equals(user.Email)));
            if (p.Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
