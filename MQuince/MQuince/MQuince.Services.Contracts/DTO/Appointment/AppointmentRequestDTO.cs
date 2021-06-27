using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Appointment
{
    public class AppointmentRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Guid DoctorId { get; set; }
        
        public Guid ReferralId { get; set; }
        public Guid SpecializationId { get; set; }
        public AppointmentPriority AppointmentPriority { get; set; }

    }
}
