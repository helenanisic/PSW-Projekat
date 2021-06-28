using Microsoft.EntityFrameworkCore;
using MQuince.Entities.MedicalRecords;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly DbContextOptions _dbContext;

        public PrescriptionRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public String Create(Prescription entity)
        {
            using PharmacyDbContext _context = new PharmacyDbContext(_dbContext);
            _context.Prescriptions.Add(PrescriptionMapper.MapPrescriptionEntityToPrescriptionPersistence(entity));
            return _context.SaveChanges() > 0 ? entity.Id : string.Empty;
        }
    }
}
