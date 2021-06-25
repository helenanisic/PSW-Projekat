using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;
using MQuince.Entities;
using MQuince.Entities.Authentication;
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
using MQuince.WebAPI;
using MQuince.WebAPI.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class PublishFeedbacks : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public IUserService _userService;
        public IFeedbackService _feedbackService;
        public PublishFeedbacks(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
            _userService = (IUserService)factory.Services.GetService(typeof(IUserService));
            _feedbackService = (IFeedbackService)factory.Services.GetService(typeof(IFeedbackService));
        }

        [Fact]
        public async Task publish_feedback_success()
        { 
            Feedback feedback = new Feedback()
            {
                Id = Guid.NewGuid(),
                Comment = "Nadam se da radi!",
                PatientId = new Guid("60fe121f-c4ee-4591-9d55-47c07c7c5616"),
                Published = false

            };
            Guid FeedbackId = _feedbackService.Create(feedback);
            
            ViewFeedbackDTO viewFeedbackDTO = new ViewFeedbackDTO()
            {
                Id = FeedbackId,
                Comment = feedback.Comment,
                PatientId = feedback.PatientId,
                Published = true
            };

            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "nikola@gmail.com",
                Password = "Nikola123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PutAsync("/api/Feedback/Update", Helpers.GetByteArrayContent(viewFeedbackDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<Feedback>(responseAsString);
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
            Assert.True(responseAsConcreteType.Published);
        }


        [Fact]
        public async Task publish_feedback_wrong_role_fail()
        {
            ViewFeedbackDTO viewFeedbackDTO = new ViewFeedbackDTO() { };

            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "helena@gmail.com",
                Password = "Helena123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PutAsync("/api/Feedback/Update", Helpers.GetByteArrayContent(viewFeedbackDTO));
            Assert.Equal(StatusCodes.Status403Forbidden, (double)response.StatusCode);
        }

    }
}

