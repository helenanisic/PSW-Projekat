using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using MQuince.Entities;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Repository.SQL.PersistenceEntities;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using MQuince.WebAPI.Controllers;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class CreateFeedback
    {
        private FeedbackController feedbackController;
        private IFeedbackService feedbackService;
        private IFeedbackRepository feedbackRepository;

        private void InitDB()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<MQuinceDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            feedbackRepository = new FeedbackRepository(optionsBuilder);
            using var dataBase = new MQuinceDbContext(optionsBuilder.Options);
            dataBase.Database.EnsureDeleted();
            dataBase.Database.EnsureCreated();
            AddFeedbacksToDB(dataBase);
        }
        private static ISession MockHttpContext()
        {
            MockHttpSession httpcontext = new MockHttpSession();
            httpcontext.SetString("UserId", "009f44e4-00dd-4f76-976b-be118844f3b4");
            return httpcontext;
        }

        private void AddFeedbacksToDB(MQuinceDbContext dataBase)
        {
            FeedbackPersistence feedback1 = new FeedbackPersistence()
            {
                Id = Guid.NewGuid(),
                Comment = "Extra!",
                Published = false,
                PatientId = Guid.NewGuid()
            };
            FeedbackPersistence feedback2 = new FeedbackPersistence()
            {
                Id = Guid.NewGuid(),
                Comment = "Uzas!",
                Published = false,
                PatientId = Guid.NewGuid()
            };
            dataBase.Feedbacks.AddRange(feedback1, feedback2);
            dataBase.SaveChanges();
        }

        public CreateFeedback()
        {
            InitDB();
            feedbackService = new FeedbackService(feedbackRepository);
            feedbackController = new FeedbackController(feedbackService);
        }

        [Fact]
        public void patient_create_feedback_success()
        {
            CreateFeedbackDTO feedbackComment = new CreateFeedbackDTO()
            {
                Comment = "Top!"
            };
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession["UserId"] = "009f44e4-00dd-4f76-976b-be118844f3b4";
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            feedbackController.ControllerContext.HttpContext = mockHttpContext.Object;

            FeedbackDTO feedback = new FeedbackDTO()
            {
                Comment = feedbackComment.Comment,
                PatientId = new Guid(mockSession.GetString("UserId")),
                Published = false
            };
            
            feedbackController.Create(feedback);
            List<Feedback> feedbacks = feedbackRepository.GetAll().ToList();

            Assert.Equal(3, feedbacks.Count());
        }
    }
}
