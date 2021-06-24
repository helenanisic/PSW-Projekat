using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Appointment
{
    public class AppointmentDTO
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public String Type { get; set; }
        public String DoctorName { get; set; }
        public String DoctorSurname { get; set; }
        public String Status { get; set; }
    }
}
