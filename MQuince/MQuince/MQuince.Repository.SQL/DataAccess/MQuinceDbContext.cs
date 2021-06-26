
using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.PersistenceEntities;
using MQuince.Repository.SQL.PersistenceEntities.Appointments;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using MQuince.Repository.SQL.PersistenceEntities.MedicalRecords;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataAccess
{
    public class MQuinceDbContext : DbContext
    {
        public DbSet<CountryPersistence> Countries { get; set; }
        public DbSet<CityPersistence> Cities { get; set; }
        public DbSet<UserPersistence> Users { get; set; }
        public DbSet<PatientPersistence> Patients { get; set; }
        public DbSet<DoctorPersistence> Doctors { get; set; }
        public DbSet<AdressPersistence> Adresses { get; set; }
        public DbSet<FeedbackPersistence> Feedbacks { get; set; }

        public DbSet<AppointmentPersistence> Appointments { get; set; }

        public DbSet<WorkSchedulePersistence> WorkSchedules { get; set; }
        public DbSet<ReferralPersistence> Referrals { get; set; }

        public MQuinceDbContext(DbContextOptions options) : base(options) { }

        public MQuinceDbContext() { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=mquince;user=root;password=root");
        }
        
    }
}
