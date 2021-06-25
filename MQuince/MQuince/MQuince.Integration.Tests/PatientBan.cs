using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Interfaces;
using MQuince.WebAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class PatientBan : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public IUserService _userService;
        public PatientBan(WebApplicationFactory<Startup> factory)
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
        public async Task view_malicious_patients_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "nikola@gmail.com",
                Password = "Nikola123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Patient/GetMaliciousPatient");
            
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<IEnumerable<PatientDTO>>(responseAsString);
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
            foreach(PatientDTO r in responseAsConcreteType)
            {
                Assert.InRange(r.MissedAppointments,3,int.MaxValue);
            }
            
        }

        [Fact]
        public async Task view_malicious_unauthorized_fail()
        {
            HttpResponseMessage response = await Client.GetAsync("/api/Patient/GetMaliciousPatient");
            Assert.Equal(StatusCodes.Status401Unauthorized, (double)response.StatusCode);
        }

        [Fact]
        public async Task view_malicious_not_admin_fail()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "helena@gmail.com",
                Password = "Helena123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Patient/GetMaliciousPatient");
            Assert.Equal(StatusCodes.Status403Forbidden, (double)response.StatusCode);
        }

        [Fact]
        public async Task ban_patient_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "nikola@gmail.com",
                Password = "Nikola123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Patient/BanPatient?id=" + new Guid("4ac0ccd6-4efa-4f19-924c-0936ac10e506"));
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);

            String email = "jovana@gmail.com";
            String password = "Jovana123";

            HttpResponseMessage response1 = await Client.GetAsync("/api/User?email=" + email + "&password=" + password);
            Assert.Equal(StatusCodes.Status401Unauthorized, (double)response1.StatusCode);
        }
    }
}
