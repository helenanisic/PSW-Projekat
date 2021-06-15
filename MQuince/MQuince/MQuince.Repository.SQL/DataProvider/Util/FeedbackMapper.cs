using MQuince.Entities;
using MQuince.Repository.SQL.PersistenceEntities;
using MQuince.Services.Contracts.DTO.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class FeedbackMapper
    {
        public static Feedback MapFeedbackPersistenceToFeedbackEntity(FeedbackPersistence feedback)
        {
            if (feedback == null) return null;

            return new Feedback(feedback.Id, feedback.Comment, feedback.PatientId, feedback.Published);

        }

        public static FeedbackPersistence MapFeedbackEntityToFeedbackPersistence(Feedback feedback)
        {
            if (feedback == null) return null;

            FeedbackPersistence retVal = new FeedbackPersistence() { Id = feedback.Id, PatientId = feedback.PatientId, Comment = feedback.Comment, Published = feedback.Published};
            return retVal;
        }

        public static IEnumerable<Feedback> MapFeedbackPersistenceCollectionToFeedbackEntityCollection(IEnumerable<FeedbackPersistence> feedbacks)
            => feedbacks.Select(c => MapFeedbackPersistenceToFeedbackEntity(c));
        public static IEnumerable<FeedbackPersistence> MapFeedbackEntityCollectionToFeedbackPersistenceCollection(
            IEnumerable<Feedback> feedbacks)
        {
            return feedbacks.Select(c => MapFeedbackEntityToFeedbackPersistence(c));
        }

        public static IEnumerable<ViewFeedbackDTO> MapFeedbackPersistenceCollectionToViewFeedbackDTOCollection(List<FeedbackPersistence> feedbacks)
            => feedbacks.Select(c => MapFeedbackPersistenceToViewFeedbackDTO(c));

        public static ViewFeedbackDTO MapFeedbackPersistenceToViewFeedbackDTO(FeedbackPersistence feedback)
        {
            if (feedback == null) return null;

            return new ViewFeedbackDTO()
            {
                Comment = feedback.Comment,
                Id = feedback.Id,
                PatientId = feedback.PatientId,
                PatientName = feedback.Patient.Name,
                PatientSurname = feedback.Patient.Surname,
                Published = feedback.Published
            };
        }
    }
}
