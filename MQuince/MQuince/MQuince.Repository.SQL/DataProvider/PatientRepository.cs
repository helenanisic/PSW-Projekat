﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Services.Contracts.DTO.Users;
using Microsoft.AspNetCore.Mvc;
using MQuince.Enums;

namespace MQuince.Repository.SQL.DataProvider
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DbContextOptions _dbContext;

        public PatientRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public Guid Create(Patient entity)
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            _context.Patients.Add(PatientMapper.MapPatientEntityToPatientPersistence(entity));
            return _context.SaveChanges() > 0 ? entity.Id : Guid.Empty;
        }
        public IEnumerable<Patient> GetAll()
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return PatientMapper.MapPatientPersistenceCollectionToPatientEntityCollection(_context.Patients.ToList());
        }

        public bool IsEmailUnique(String email)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return PatientMapper.MapPatientPersistenceToPatientEntity(context.Patients.SingleOrDefault(p => p.Email.Equals(email))) is null;
        }

        public IEnumerable<Patient> GetMaliciousPatients()
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return PatientMapper.MapPatientPersistenceCollectionToPatientEntityCollection(context.Patients.Where(p => p.MissedAppointments >= 3).ToList());
        }

        public Patient BanPatient(Patient patient)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            Patient ret = PatientMapper.MapPatientPersistenceToPatientEntity(context.Update(PatientMapper.MapPatientEntityToPatientPersistence(patient)).Entity);
            context.SaveChanges();
            return ret;
        }

        public Patient GetById(Guid id)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return PatientMapper.MapPatientPersistenceToPatientEntity(context.Patients.SingleOrDefault(p => p.Id.Equals(id)));
        }

        public IEnumerable<Patient> GetAllNotBanned()
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return PatientMapper.MapPatientPersistenceCollectionToPatientEntityCollection(_context.Patients.Where(p => p.Banned == false & p.UserType == Enums.Usertype.Patient).ToList());
        }
    }
}
