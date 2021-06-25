using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Entities;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.Interfaces;
using MQuince.WebAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class RemoveFeedback : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public IUserService _userService;
        public IFeedbackService _feedbackService;
        public RemoveFeedback(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
            _userService = (IUserService)factory.Services.GetService(typeof(IUserService));
            _feedbackService = (IFeedbackService)factory.Services.GetService(typeof(IFeedbackService));
        }

        [Fact]
        public async Task remove_feedback_success()
        {
            Feedback feedback = new Feedback()
            {
                Id = Guid.NewGuid(),
                Comment = "Nadam se da radi!",
                PatientId = new Guid("60fe121f-c4ee-4591-9d55-47c07c7c5616"),
                Published = true

            };
            Guid FeedbackId = _feedbackService.Create(feedback);

            ViewFeedbackDTO viewFeedbackDTO = new ViewFeedbackDTO()
            {
                Id = feedback.Id,
                Comment = feedback.Comment,
                PatientId = feedback.PatientId,
                Published = false
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
            Assert.False(responseAsConcreteType.Published);
        }
    }
}
