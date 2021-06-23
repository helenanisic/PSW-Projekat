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
        public RemoveFeedback(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
            _userService = (IUserService)factory.Services.GetService(typeof(IUserService));
        }
        public static ByteArrayContent GetByteArrayContent(object o)
        {
            var myContent = JsonConvert.SerializeObject(o);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }


        [Fact]
        public async Task remove_feedback_success()
        {
            ViewFeedbackDTO viewFeedbackDTO = new ViewFeedbackDTO()
            {
                Id = new Guid("d98ace89-f121-4248-beb7-eb366dd39ebf"),
                Comment = "Nadam se da radi",
                PatientId = new Guid("b2b2a4e8-7eef-42f5-bca6-16f25f7d7c56"),
                Published = false
            };

            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "nikola@gmail",
                Password = "nikolaBlesic123"
            };

            AuthenticateResponse authenticatedUser = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authenticatedUser.Token);
            HttpResponseMessage response = await Client.PutAsync("/api/Feedback/Update", GetByteArrayContent(viewFeedbackDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<Feedback>(responseAsString);
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
            Assert.False(responseAsConcreteType.Published);
        }
    }
}
