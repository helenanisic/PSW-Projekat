using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO;
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
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IdentifiableDTO<FeedbackDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(FeedbackDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
