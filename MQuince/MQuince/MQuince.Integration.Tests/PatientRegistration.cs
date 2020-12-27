using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using Xunit;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using MQuince.WebAPI.Controllers;
using MQuince.Repository.SQL.PersistenceEntities.Users;

namespace MQuince.Integration.Tests
{
    public class PatientRegistration
    {
        private PatientController patientController;
        private IPatientService patientService;
        private IPatientRepository patientRepository;

        private void InitDB()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<MQuinceDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            patientRepository = new PatientRepository(optionsBuilder);
            using var dataBase = new MQuinceDbContext(optionsBuilder.Options);
            dataBase.Database.EnsureDeleted();
            dataBase.Database.EnsureCreated();
            AddPatientstoDB(dataBase);
        }

        private void AddPatientstoDB(MQuinceDbContext dataBase)
        {
            PatientPersistence patient1 = new PatientPersistence()
            {
                Id = Guid.NewGuid(),
                Name = "Mara",
                Surname = "Maric"
            };
            PatientPersistence patient2 = new PatientPersistence()
            {
                Id = Guid.NewGuid(),
                Name = "Marko",
                Surname = "Markovic"
            };
            dataBase.Patients.AddRange(patient1, patient2);
            dataBase.SaveChanges();
        }

        public PatientRegistration()
        {
            InitDB();
            patientService = new PatientService(patientRepository);
            patientController = new PatientController(patientService);
        }

        [Fact]
        public void patient_registration_success()
        {
            PatientDTO patient = new PatientDTO()
            {
                Name = "Nikola",
                Surname = "Nikolic"
            };

            patientController.Create(patient);
            List<Patient> patients = patientRepository.GetAll().ToList();

            Assert.Equal(3, patients.Count());
        }
    }
}
