using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class WorkScheduleMapper
    {
        public static WorkSchedule MapWorkSchedulePersistenceToWorkScheduleEntity(WorkSchedulePersistence workSchedule)
        => workSchedule == null ? null : new WorkSchedule(workSchedule.Id, workSchedule.Date, workSchedule.StartTime, workSchedule.EndTime, DoctorMapper.MapDoctorPersistenceToDoctorEntity(workSchedule.Doctor));

        public static IEnumerable<WorkSchedule> MapWorkSchedulePersistenceCollectionToWorkScheduleEntityCollection(IEnumerable<WorkSchedulePersistence> workSchedules)
            => workSchedules.Select(c => MapWorkSchedulePersistenceToWorkScheduleEntity(c));

        public static IEnumerable<WorkSchedulePersistence> MapWorkScheduleEntityCollectionToWorkSchedulePersistenceCollection(IEnumerable<WorkSchedule> workSchedules)
            => workSchedules.Select(c => MapWorkScheduleEntityToWorkSchedulePersistence(c));

        public static WorkSchedulePersistence MapWorkScheduleEntityToWorkSchedulePersistence(WorkSchedule workSchedule)
        {
            if (workSchedule == null) return null;
            WorkSchedulePersistence retVal = new WorkSchedulePersistence()
            {
                Id = workSchedule.Id,
                Date = workSchedule.Date,
                StartTime = workSchedule.StartTime,
                EndTime = workSchedule.EndTime,
                DoctorId = workSchedule.Doctor.Id
            };

            return retVal;
        }
    }
}
