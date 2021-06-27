using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Appointment
{
    public class AppointmentDTO
    {
        public Guid id { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public String Type { get; set; }
        public Guid DoctorId { get; set; }
        public String DoctorName { get; set; }
        public String DoctorSurname { get; set; }
        public String Status { get; set; }
    }
}
