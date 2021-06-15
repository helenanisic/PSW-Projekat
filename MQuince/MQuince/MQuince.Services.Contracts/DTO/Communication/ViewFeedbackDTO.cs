using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Communication
{
    public class ViewFeedbackDTO
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public bool Published { get; set; } = false;
    }
}
