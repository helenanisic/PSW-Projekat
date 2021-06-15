using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQuince.Entities;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.Services.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        } 
        
        public Guid Create(FeedbackDTO entityDTO)
        {
            return _feedbackRepository.Create(CreateFeedbackFromDTO(entityDTO));
            
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ViewFeedbackDTO> GetAllFeedbacks()
        {
            return _feedbackRepository.GetAllFeedbacks();
        }

        public IdentifiableDTO<FeedbackDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewFeedbackDTO> GetNotPublishedFeedbacks() 
            => _feedbackRepository.GetNotPublishedFeedbacks();

        public IEnumerable<ViewFeedbackDTO> GetPublishedFeedbacks()
            => _feedbackRepository.GetPublishedFeedbacks();

        public bool Update(FeedbackDTO entityDTO, Guid id)
        {
            return _feedbackRepository.Update(CreateFeedbackFromDTO(entityDTO, id));
        }

        private IdentifiableDTO<FeedbackDTO> CreateFeedbackDTO(Feedback feedback)
        {
            if (feedback == null) return null;

            return new IdentifiableDTO<FeedbackDTO>()
            {
                Id = feedback.Id,
                EntityDTO = new FeedbackDTO()
                {
                    Comment = feedback.Comment,
                    PatientId = feedback.PatientId,
                    Published = feedback.Published
                }
            };
        }

        private Feedback CreateFeedbackFromDTO(FeedbackDTO feedback, Guid? id = null)
            => id == null ? new Feedback(feedback.Comment, feedback.PatientId, feedback.Published)
                : new Feedback(id.Value, feedback.Comment, feedback.PatientId, feedback.Published);
    }
}
