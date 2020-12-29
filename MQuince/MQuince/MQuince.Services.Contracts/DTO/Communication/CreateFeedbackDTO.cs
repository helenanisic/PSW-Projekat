using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace MQuince.Services.Contracts.DTO.Communication
{
    public class FeedbackCommentDTO
    {
        [Required]
        [StringLength(500,MinimumLength = 1)]
        public string Comment { get; set; }
    }
}
