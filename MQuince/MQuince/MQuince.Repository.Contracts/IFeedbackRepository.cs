using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Entities;
using MQuince.Services.Contracts.DTO.Communication;

namespace MQuince.Repository.Contracts
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        IEnumerable<ViewFeedbackDTO> GetNotPublishedFeedbacks();
        IEnumerable<ViewFeedbackDTO> GetPublishedFeedbacks();
        IEnumerable<ViewFeedbackDTO> GetAllFeedbacks();
    }
}
