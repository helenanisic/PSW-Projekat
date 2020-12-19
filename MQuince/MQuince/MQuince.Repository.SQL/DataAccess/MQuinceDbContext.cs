﻿
using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.PersistenceEntities;
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
        public DbSet<UserPersistence> Users { get; set; }

        public MQuinceDbContext(DbContextOptions options) : base(options) { }

        public MQuinceDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=mquince;user=root;password=root");
        }

    }
}
