using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Drug;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly DbContextOptions _dbContext;

        public MedicineRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<Medicine> GetAll()
        {
            using PharmacyDbContext context = new PharmacyDbContext(_dbContext);
            return MedicineMapper.MapMedicinePersistenceCollectionToMedicineEntityCollection(context.Medicines.ToList());
        }
    }
}
