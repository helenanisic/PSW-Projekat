using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataAccess
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<MedicinePersistence> Medicines { get; set; }
        public PharmacyDbContext(DbContextOptions options) : base(options) { }
    }
}
