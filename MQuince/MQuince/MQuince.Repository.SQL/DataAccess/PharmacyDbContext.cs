using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using MQuince.Repository.SQL.PersistenceEntities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataAccess
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<MedicinePersistence> Medicines { get; set; }
        public DbSet<PrescriptionPersistence> Prescriptions { get; set; }
        public DbSet<MedicineInPharmacyPersistence> MedicineInPharmacy { get; set; }

        public PharmacyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineInPharmacyPersistence>()
                .HasKey(c => new { c.medicine_id, c.pharmacy_id });
        }
    }
}
