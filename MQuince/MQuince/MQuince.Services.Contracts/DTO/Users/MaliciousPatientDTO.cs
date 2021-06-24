
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class MaliciousPatientDTO
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int MissedAppointments { get; set; }
        public bool Banned { get; set; }
    }
}
