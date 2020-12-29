using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Services.Contracts.DTO
{
    public class FeedbackDTO
    {
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Comment { get; set; }
        [Required]
        public Guid PatientId { get; set; }

        public bool Published { get; set; } = false;
    }
}
