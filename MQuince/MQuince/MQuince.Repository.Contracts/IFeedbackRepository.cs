using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities;
using MQuince.Services.Contracts.DTO.Communication;

namespace MQuince.Repository.Contracts
{
    public interface IFeedbackRepository
    {
        IEnumerable<ViewFeedbackDTO> GetNotPublishedFeedbacks();
        IEnumerable<ViewFeedbackDTO> GetPublishedFeedbacks();
        IEnumerable<ViewFeedbackDTO> GetAllFeedbacks();
        Guid Create(Feedback entity);
        Feedback Update(Feedback entity);
        IEnumerable<Feedback> GetAll();
    }
}
