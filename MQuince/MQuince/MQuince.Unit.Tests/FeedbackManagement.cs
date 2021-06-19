using Moq;
using MQuince.Entities;
using MQuince.Repository.Contracts;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Unit.Tests
{
    public class FeedbackManagement
    {
        [Fact]
        public void write_feedback_success()
        {
            Feedback feedback = new Feedback()
            {
                Id = new Guid("2270bae8-9f26-3ea5-b20d-0ce11ead067e"),
                Comment = "testic",
                PatientId = new Guid("2270bae8-9f26-4ea5-b20d-0ce11ead067e")
            };
            var stubRepository = new Mock<IFeedbackRepository>();
            stubRepository.Setup(p => p.Create(feedback)).Returns(new Guid("2270bae8-9f26-3ea5-b20d-0ce11ead067e"));
            FeedbackService feedbackService = new FeedbackService(stubRepository.Object);

            Guid id = feedbackService.Create(feedback);

            Assert.Equal(new Guid("2270bae8-9f26-3ea5-b20d-0ce11ead067e"), id);
            
        }
    }
}
