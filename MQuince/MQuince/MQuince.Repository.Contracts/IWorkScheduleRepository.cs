using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IWorkScheduleRepository
    {
        IEnumerable<WorkSchedule> FindWorkScheduleForDoctorInDateRange(DateTime startDate, DateTime endDate, Guid DoctorId);
        IEnumerable<WorkSchedule> FindWorkScheduleForAllDoctorsInDateRange(DateTime startDate, DateTime endDate, Guid specializationId);
    }
}
