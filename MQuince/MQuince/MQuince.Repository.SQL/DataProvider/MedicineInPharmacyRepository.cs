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
    public class MedicineInPharmacyRepository : IMedicineInPharmacyRepository
    {
        private readonly DbContextOptions _dbContext;

        public MedicineInPharmacyRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public MedicineInPharmacy GetMedicineInPharmacy(int medicineId)
        {
            using (PharmacyDbContext _context = new PharmacyDbContext(_dbContext))
            {
                return MedicineInPharmacyMapper.MapMedicineInPharmacyPersistenceToMedicineInPharmacyEntity(_context.MedicineInPharmacy.SingleOrDefault(c => c.pharmacy_id == 1 && c.medicine_id == medicineId));
            }
        }
    }
}
