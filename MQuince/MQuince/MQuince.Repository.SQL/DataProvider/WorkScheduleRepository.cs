using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class WorkScheduleRepository : IWorkScheduleRepository
    {
        private readonly DbContextOptions _dbContext;

        public WorkScheduleRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<WorkSchedule> FindWorkScheduleForDoctorInDateRange(DateTime startDate, DateTime endDate, Guid DoctorId)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return WorkScheduleMapper.MapWorkSchedulePersistenceCollectionToWorkScheduleEntityCollection(context.WorkSchedules.Include("Doctor").Where(d => d.DoctorId.Equals(DoctorId) & d.Date >= startDate & d.Date <= endDate).ToList());
        }

        public IEnumerable<WorkSchedule> FindWorkScheduleForAllDoctorsInDateRange(DateTime startDate, DateTime endDate, Guid specializationId)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return WorkScheduleMapper.MapWorkSchedulePersistenceCollectionToWorkScheduleEntityCollection(context.WorkSchedules.Include("Doctor").Where(d => d.Date >= startDate & d.Date <= endDate & d.Doctor.SpecializationId == specializationId).ToList());
        }
    }
}
