using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class WorkSchedule
    {
        public Guid Id;
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Doctor Doctor { get; set; }

        public WorkSchedule()
        {
            Id = Guid.NewGuid();
        }
        public WorkSchedule(DateTime date, int startTime, int endTime, Doctor doctor) : this(Guid.NewGuid(), date, startTime, endTime, doctor) { }
        public WorkSchedule(Guid id, DateTime date, int startTime, int endTime, Doctor doctor)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            Doctor = doctor;
        }
    }
}
