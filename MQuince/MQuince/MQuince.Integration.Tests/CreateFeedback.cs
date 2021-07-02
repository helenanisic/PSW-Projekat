using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MQuince.Entities;
using MQuince.Entities.Authentication;
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
using MQuince.WebAPI;
using MQuince.WebAPI.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class CreateFeedback : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public IUserService _userService;
        public CreateFeedback(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
            _userService = (IUserService)factory.Services.GetService(typeof(IUserService));
        }

        [Fact]
        public async Task create_feedback_success()
        {
            FeedbackCommentDTO feedbackDTO = new FeedbackCommentDTO()
            {
                Comment = "Test!"
            };
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "helena@gmail.com",
                Password = "Helena123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PostAsync("/api/Feedback", Helpers.GetByteArrayContent(feedbackDTO));
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
        }

        [Fact]
        public async Task create_feedback_unauthorized_fail()
        {
            FeedbackCommentDTO feedbackDTO = new FeedbackCommentDTO()
            {
                Comment = "Test!"
            };
            HttpResponseMessage response = await Client.PostAsync("/api/Feedback", Helpers.GetByteArrayContent(feedbackDTO));
            Assert.Equal(StatusCodes.Status401Unauthorized, (double)response.StatusCode);
        }
    }
}
