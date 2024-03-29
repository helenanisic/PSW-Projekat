﻿using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IFeedbackService
    {
        IEnumerable<ViewFeedbackDTO> GetNotPublishedFeedbacks();
        IEnumerable<ViewFeedbackDTO> GetPublishedFeedbacks();
        IEnumerable<ViewFeedbackDTO> GetAllFeedbacks();

        Guid Create(Feedback feedback);
        Feedback Update(FeedbackDTO entityDTO, Guid id);
    }
}
