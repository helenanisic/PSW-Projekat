using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Application;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.Interfaces;
using MQuince.WebAPI;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class Appointments : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public IUserService _userService;
        public Appointments(WebApplicationFactory<Startup> factory)
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
        public async Task view_appointments_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "helena@gmail.com",
                Password = "Helena123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Appointment/GetAppointmentsForPatient");
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<IEnumerable<AppointmentDTO>>(responseAsString);
            IEnumerable<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
            Assert.NotEqual(appointmentDTOs, responseAsConcreteType);
        }

        [Fact]
        public async Task view_appointments_unauthorized_fail()
        {
            HttpResponseMessage response = await Client.GetAsync("/api/Appointment/GetAppointmentsForPatient");
            Assert.Equal(StatusCodes.Status401Unauthorized, (double)response.StatusCode);
        }

        [Fact]
        public async Task view_appointments_wrong_role_fail()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "nikola@gmail.com",
                Password = "Nikola123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Appointment/GetAppointmentsForPatient");
            Assert.Equal(StatusCodes.Status403Forbidden, (double)response.StatusCode);
        }

        [Fact]
        public async Task view_appointments_empty_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "andrej@gmail.com",
                Password = "Andrej123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Appointment/GetAppointmentsForPatient");
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<IEnumerable<AppointmentDTO>>(responseAsString);
            IEnumerable<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
            Assert.Equal(appointmentDTOs, responseAsConcreteType);
        }

        [Fact]
        public async Task recommend_appointment_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "andrej@gmail.com",
                Password = "Andrej123"
            };
            AppointmentRequestDTO appointmentRequestDTO = new AppointmentRequestDTO()
            {
                StartDate = new DateTime(2020, 06, 17),
                EndDate = new DateTime(2020, 06, 20),
                DoctorId = new Guid("fdea1b1d-bafc-4056-b5aa-6bacd468d080"),
                appointmentPriority = Enums.AppointmentPriority.DoctorPriority,
                StartTime = 8,
                EndTime = 18,
                SpecializationId = new Guid("75910c98-913d-43d9-a012-ad8fa3cc4045")
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PostAsync("/api/Appointment/Recommend", Helpers.GetByteArrayContent(appointmentRequestDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<AppointmentDTO>(responseAsString);
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
            Assert.NotNull(responseAsConcreteType);
        }

        [Fact]
        public async Task recommend_appointment_doctor_priority_fail()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "andrej@gmail.com",
                Password = "Andrej123"
            };
            AppointmentRequestDTO appointmentRequestDTO = new AppointmentRequestDTO()
            {
                StartDate = new DateTime(2020, 07, 17),
                EndDate = new DateTime(2020, 07, 20),
                DoctorId = new Guid("fdea1b1d-bafc-4056-b5aa-6bacd468d080"),
                appointmentPriority = Enums.AppointmentPriority.DoctorPriority,
                StartTime = 8,
                EndTime = 18,
                SpecializationId = new Guid("75910c98-913d-43d9-a012-ad8fa3cc4045")
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PostAsync("/api/Appointment/Recommend", Helpers.GetByteArrayContent(appointmentRequestDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<AppointmentDTO>(responseAsString);
            Assert.Equal(StatusCodes.Status204NoContent, (double)response.StatusCode);
            Assert.Null(responseAsConcreteType);

        }

        [Fact]
        public async Task recommend_appointment_time_priority_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "andrej@gmail.com",
                Password = "Andrej123"
            };
            AppointmentRequestDTO appointmentRequestDTO = new AppointmentRequestDTO()
            {
                StartDate = new DateTime(2020, 06, 25),
                EndDate = new DateTime(2020, 06, 27),
                DoctorId = new Guid("fdea1b1d-bafc-4056-b5aa-6bacd468d080"),
                appointmentPriority = Enums.AppointmentPriority.DatePriority,
                StartTime = 8,
                EndTime = 18,
                SpecializationId = new Guid("75910c98-913d-43d9-a012-ad8fa3cc4045")
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PostAsync("/api/Appointment/Recommend", Helpers.GetByteArrayContent(appointmentRequestDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<AppointmentDTO>(responseAsString);
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
            responseAsConcreteType.DoctorId.ShouldBe(new Guid("b35f2726-7757-42dd-92cc-9a6f5ff1b759"));
        }
    }
}
