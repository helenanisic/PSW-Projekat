using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class DoctorDTO : UserDTO
    {
        public Guid SpecializationId { get; set; }
    }
}
