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
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using MQuince.WebAPI.Controllers;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class PublishFeedbacks
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
            AddFeedbackstoDB(dataBase);
        }

        private void AddFeedbackstoDB(MQuinceDbContext dataBase)
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
                Id = new Guid("009f44e4-00dd-4f76-976b-be118844f3b4"),
                Comment = "Uzas!",
                Published = false,
                PatientId = new Guid("77b7aad8-ef34-484f-bd05-77f435bbc0c3")
            };

            PatientPersistence patient = new PatientPersistence()
            {
                Id = new Guid("77b7aad8-ef34-484f-bd05-77f435bbc0c3"),
                Jmbg = "1234567891234",
                BirthDate = new DateTime(),
                Gender = Enums.Gender.Female,
                Telephone = "123456",
                UserType = Enums.Usertype.Patient,
                Name = "Helena",
                Surname = "Anisic",
                Email = "helenanisic@gmail.com",
                Password = "Helena123"
            };
            dataBase.Patients.Add(patient);
            dataBase.Feedbacks.AddRange(feedback1, feedback2);
            dataBase.SaveChanges();
        }

        public PublishFeedbacks()
        {
            InitDB();
            feedbackService = new FeedbackService(feedbackRepository);
            feedbackController = new FeedbackController(feedbackService);
        }

        [Fact]
        public void admin_publish_feedback_success()
        {
            ViewFeedbackDTO feedback = new ViewFeedbackDTO()
            {
                Id = new Guid("009f44e4-00dd-4f76-976b-be118844f3b4"),
                Comment = "Uzas!",
                Published = true,
                PatientId = new Guid("77b7aad8-ef34-484f-bd05-77f435bbc0c3")
            };
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession["UserId"] = "009f44e4-00dd-4f76-976b-be118844f3b4";
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            feedbackController.ControllerContext.HttpContext = mockHttpContext.Object;


            feedbackController.Update(feedback);
            List<ViewFeedbackDTO> Publishedfeedbacks = feedbackRepository.GetNotPublishedFeedbacks().ToList();

            Assert.Single(Publishedfeedbacks);
        }
    }
}
