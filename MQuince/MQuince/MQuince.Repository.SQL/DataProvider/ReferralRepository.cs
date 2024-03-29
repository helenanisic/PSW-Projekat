﻿
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.MedicalRecords;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly DbContextOptions _dbContext;

        public ReferralRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<Referral> GetReferralOfPatient(Guid patientId, bool used)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return ReferralMapper.MapReferralPersistenceCollectionToReferralEntityCollection(context.Referrals.Include("Patient").Include("Specialization").Where(a => a.PatientId == patientId && a.Used == used).ToList());
        }

        public Referral Update(Referral entity)
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            Referral referral = ReferralMapper.MapReferralPersistenceToReferralEntity(_context.Update(ReferralMapper.MapReferralEntityToReferralPersistence(entity)).Entity);
            _context.SaveChanges();
            return referral;
        }

    }
}
