using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Entities.Authentication;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.MedicalRecords;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Interfaces;
using MQuince.WebAPI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class Prescriptions : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public IUserService _userService;
        public Prescriptions(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
            _userService = (IUserService)factory.Services.GetService(typeof(IUserService));
        }

        [Fact]
        public async Task create_prescription_success()
        {
            PatientDTO patient = new PatientDTO()
            {
                Name = "Milan",
                Id = new Guid("60fe121f-c4ee-4591-9d55-47c07c7c5616"),
                Jmbg = "1234567891234"
            };
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO()
            {
                MedicineId = 2,
                Patient = patient,
                Quantity = 1
            };

            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "mara@gmail.com",
                Password = "Mara123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PostAsync("/api/Prescription", Helpers.GetByteArrayContent(prescriptionDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
        }

        [Fact]
        public async Task create_prescription_wrong_role_fail()
        {
            PatientDTO patient = new PatientDTO()
            {
                Name = "Milan",
                Id = new Guid("60fe121f-c4ee-4591-9d55-47c07c7c5616")
            };
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO()
            {
                MedicineId = 2,
                Patient = patient,
                Quantity = 1
            };

            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "nikola@gmail.com",
                Password = "Nikola123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PostAsync("/api/Prescription", Helpers.GetByteArrayContent(prescriptionDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.Equal(StatusCodes.Status403Forbidden, (double)response.StatusCode);
        }

        [Fact]
        public async Task create_prescription_quantity_fail()
        {
            PatientDTO patient = new PatientDTO()
            {
                Name = "Milan",
                Id = new Guid("60fe121f-c4ee-4591-9d55-47c07c7c5616")
            };
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO()
            {
                MedicineId = 2,
                Patient = patient,
                Quantity = 50
            };

            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "mara@gmail.com",
                Password = "Mara123"
            };

            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.PostAsync("/api/Prescription", Helpers.GetByteArrayContent(prescriptionDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.Equal(StatusCodes.Status400BadRequest, (double)response.StatusCode);

            
        }
    }
}
